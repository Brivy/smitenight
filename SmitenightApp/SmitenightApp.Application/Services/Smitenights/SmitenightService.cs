using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Common;
using SmitenightApp.Abstractions.Application.Services.Matches;
using SmitenightApp.Abstractions.Application.Services.Players;
using SmitenightApp.Abstractions.Application.Services.Smitenights;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Application.Services.Players;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Smitenights;
using SmitenightApp.Domain.Enums.StatusCodes;
using SmitenightApp.Domain.Models.Smitenights;
using SmitenightApp.Persistence;
using SmitenightApp.Domain.Models.Players;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.PlayerResponses;

namespace SmitenightApp.Application.Services.Smitenights
{
    public class SmitenightService : ISmitenightService
    {
        private readonly IPlayerInfoClient _playerInfoClient;
        private readonly IRetrievePlayerClient _retrievePlayerClient;
        private readonly IImportMatchService _importMatchService;
        private readonly ISmitenightBuilderService _smitenightBuilderService;
        private readonly IPlayerService _playerService;
        private readonly IPlayerNameAttemptService _playerNameAttemptService;
        private readonly IClock _clock;
        private readonly IMapper _mapper;
        private readonly SmitenightDbContext _dbContext;

        public SmitenightService(
            IPlayerInfoClient playerInfoClient,
            IRetrievePlayerClient retrievePlayerClient,
            IImportMatchService importMatchService,
            ISmitenightBuilderService smitenightBuilderService,
            IPlayerService playerService,
            IPlayerNameAttemptService playerNameAttemptService,
            IClock clock,
            IMapper mapper,
            SmitenightDbContext dbContext)
        {
            _playerInfoClient = playerInfoClient;
            _retrievePlayerClient = retrievePlayerClient;
            _importMatchService = importMatchService;
            _smitenightBuilderService = smitenightBuilderService;
            _playerService = playerService;
            _playerNameAttemptService = playerNameAttemptService;
            _clock = clock;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default)
        {
            var playerNameAlreadyTried = await _playerNameAttemptService.PlayerNameAlreadyTriedAsync(playerName, cancellationToken);
            if (playerNameAlreadyTried)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerNameTriedWithinCooldownPeriod);
            }

            var existingPlayer = await _playerService.GetAlreadyExistingAsync(playerName, cancellationToken);
            if (existingPlayer == null)
            {
                return await HandleNewPlayerSmiteNightAsync(playerName, pinCode, cancellationToken);
            }

            return await HandleExistingPlayerSmiteNightAsync(existingPlayer, pinCode, cancellationToken);
        }

        public async Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default)
        {
            var smiteIdFromPlayerWithSmitenight = await GetSmiteIdFromPlayerWithSmitenightQueryAsync(playerName, pinCode, cancellationToken);
            if (!smiteIdFromPlayerWithSmitenight.HasValue)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.SmitenightNotFound);
            }

            var playerHistoryResponse = await _playerInfoClient.GetMatchHistoryAsync(smiteIdFromPlayerWithSmitenight.Value.ToString(), cancellationToken);
            if (playerHistoryResponse?.Response?.Any() != true)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerHistoryNotFoundInSmite);
            }

            // Update the end date of the Smitenight
            var smitenight = await GetLatestSmitenightFromPlayerAsync(smiteIdFromPlayerWithSmitenight.Value, cancellationToken);
            smitenight.EndDate = _clock.Now();
            _dbContext.Smitenights.Update(smitenight);

            // Update the smitenight with all the match history
            var smitenightMatchIds = GetSmitenightMatchIds(playerHistoryResponse.Response, smitenight.StartDate);
            var matchEntityIds = await GetMatchIdsAsync(smitenightMatchIds, cancellationToken);
            var smitenightMatches = matchEntityIds.Select(matchEntityId => new SmitenightMatch { MatchId = matchEntityId, SmitenightId = smitenight.Id }).ToList();
            _dbContext.SmitenightMatches.AddRange(smitenightMatches);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.Success, _mapper.Map<SmitenightDto>(smitenight));
        }

        #region Handle kinds of Smitenights

        private async Task<ServerResponseDto<SmitenightDto>> HandleNewPlayerSmiteNightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default)
        {
            var playerIdResponse = await _retrievePlayerClient.GetPlayerIdByPlayerNameAsync(playerName, cancellationToken);
            if (playerIdResponse?.Response?.Any() != true)
            {
                await _playerNameAttemptService.RegisterNotFoundPlayerNameAsync(playerName, cancellationToken);
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerByPlayerNameNotFoundInSmite);
            }

            var smitePlayer = playerIdResponse.Response.First();
            if (smitePlayer.PrivacyFlag == ResponseConstants.Yes)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerHasPrivacyEnabled);
            }

            Smitenight smitenight;
            var playerEntity = await GetPlayerWithSmitenightQueryAsync(smitePlayer.PlayerId, cancellationToken);
            if (playerEntity == null)
            {
                var player = await _retrievePlayerClient.GetPlayerWithoutPortalAsync(smitePlayer.PlayerId.ToString(), cancellationToken);
                if (player?.Response?.Any() != true || player.Response.First().Id == ResponseConstants.AnonymousPlayerIntId)
                {
                    return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerByPlayerIdNotFoundInSmite);
                }

                smitenight = _smitenightBuilderService.Build(player.Response.First(), pinCode);
            }
            else
            {
                if (playerEntity.Smitenights.Any(x => !x.EndDate.HasValue))
                {
                    return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.SmitenightAlreadyFound);
                }

                smitenight = _smitenightBuilderService.Build(playerEntity.Id, pinCode);
            }

            _dbContext.Add(smitenight);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.Success, _mapper.Map<SmitenightDto>(smitenight));
        }

        private async Task<ServerResponseDto<SmitenightDto>> HandleExistingPlayerSmiteNightAsync(Player existingPlayer, string? pinCode, CancellationToken cancellationToken = default)
        {
            if (existingPlayer.PrivacyEnabled)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerHasPrivacyEnabled);
            }

            var smitenightExists = await _dbContext.Smitenights.AnyAsync(x => x.PlayerId == existingPlayer.Id && !x.EndDate.HasValue, cancellationToken);
            if (smitenightExists)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.SmitenightAlreadyFound);
            }

            var smitenight = _smitenightBuilderService.Build(existingPlayer.Id, pinCode);
            _dbContext.Add(smitenight);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.Success, _mapper.Map<SmitenightDto>(smitenight));
        }

        #endregion

        #region Queries

        private async Task<int?> GetSmiteIdFromPlayerWithSmitenightQueryAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default) =>
            await _dbContext.Players
                .AsNoTracking()
                .Where(x => x.HirezPlayerName == playerName && 
                               x.Smitenights.Any(y => y.PinCode == pinCode && !y.EndDate.HasValue))
                .Select(x => x.SmiteId).SingleOrDefaultAsync(cancellationToken);

        private async Task<Player?> GetPlayerWithSmitenightQueryAsync(int smiteId, CancellationToken cancellationToken = default) =>
            await _dbContext.Players
                .AsNoTracking()
                .Include(x => x.Smitenights)
                .Where(x => x.SmiteId == smiteId)
                .SingleOrDefaultAsync(cancellationToken);

        private async Task<Smitenight> GetLatestSmitenightFromPlayerAsync(int smiteId, CancellationToken cancellationToken = default) =>
            await _dbContext.Smitenights
                .Where(x => x.Player != null && x.Player.SmiteId == smiteId)
                .OrderByDescending(x => x.Id)
                .FirstAsync(cancellationToken);

        #endregion

        #region Private functionality

        private List<int> GetSmitenightMatchIds(List<MatchHistoryResponse> matchHistories, DateTime smitenightStartDate)
        {
            var smitenightMatchIds = new List<int>();
            matchHistories.ForEach(matchHistory =>
            {
                if (!DateTime.TryParse(matchHistory.MatchTime, out var startTime))
                {
                    return;
                }

                if (startTime >= smitenightStartDate)
                {
                    smitenightMatchIds.Add(matchHistory.Match);
                }
            });

            return smitenightMatchIds;
        }

        private async Task<List<int>> GetMatchIdsAsync(List<int> smitenightMatchIds, CancellationToken cancellationToken = default)
        {
            var matchIds = new List<int>();
            if (smitenightMatchIds.Count == 1)
            {
                var matchId = await _importMatchService.ImportAsync(smitenightMatchIds.Single(), cancellationToken);
                if (matchId.HasValue)
                {
                    matchIds.Add(matchId.Value);
                }
            }
            else
            {
                const int batchSize = 5;
                var totalCallsToApi = (smitenightMatchIds.Count - 1) / batchSize + 1;
                for (var i = 0; i < totalCallsToApi; i++)
                {
                    var currentBatch = smitenightMatchIds.Skip(i * batchSize).Take(batchSize).ToList();
                    var batchMatchIds = await _importMatchService.ImportAsync(currentBatch, cancellationToken);
                    if (batchMatchIds.Any())
                    {
                        matchIds.AddRange(batchMatchIds);
                    }
                }
            }

            return matchIds;
        }

        #endregion
    }
}
