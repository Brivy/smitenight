using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Common;
using SmitenightApp.Abstractions.Application.Services.Matches;
using SmitenightApp.Abstractions.Application.Services.Smitenights;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Smitenights;
using SmitenightApp.Domain.Enums.StatusCodes;
using SmitenightApp.Domain.Models.Smitenights;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Smitenights
{
    public class SmitenightService : ISmitenightService
    {
        private readonly IPlayerInfoClient _playerInfoClient;
        private readonly IRetrievePlayerClient _retrievePlayerClient;
        private readonly IImportMatchService _importMatchService;
        private readonly ISmitenightBuilderService _smitenightBuilderService;
        private readonly IClock _clock;
        private readonly IMapper _mapper;
        private readonly SmitenightDbContext _dbContext;

        public SmitenightService(
            IPlayerInfoClient playerInfoClient,
            IRetrievePlayerClient retrievePlayerClient,
            IImportMatchService importMatchService,
            ISmitenightBuilderService smitenightBuilderService,
            IClock clock,
            IMapper mapper,
            SmitenightDbContext dbContext)
        {
            _playerInfoClient = playerInfoClient;
            _retrievePlayerClient = retrievePlayerClient;
            _importMatchService = importMatchService;
            _smitenightBuilderService = smitenightBuilderService;
            _clock = clock;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default)
        {
            var playerIdRequest = new PlayerIdByNameRequest(playerName);
            var playerIdResponse = await _retrievePlayerClient.GetPlayerIdByPlayerNameAsync(playerIdRequest, cancellationToken);
            if (playerIdResponse?.Response?.Any() != true)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerByPlayerNameNotFoundInSmite);
            }

            var smitePlayer = playerIdResponse.Response.First();
            if (smitePlayer.PrivacyFlag == ResponseConstants.Yes)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerHasPrivacyEnabled);
            }

            Smitenight smitenight;
            var playerEntity = await _dbContext.Players.AsNoTracking().Where(x => x.SmiteId == smitePlayer.PlayerId).SingleOrDefaultAsync(cancellationToken);
            if (playerEntity == null)
            {
                var playerRequest = new PlayerWithoutPortalRequest(smitePlayer.PlayerId.ToString());
                var player = await _retrievePlayerClient.GetPlayerWithoutPortalAsync(playerRequest, cancellationToken);
                if (player?.Response?.Any() != true || player.Response.First().Id == ResponseConstants.AnonymousPlayerIntId)
                {
                    return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerByPlayerIdNotFoundInSmite);
                }

                smitenight = _smitenightBuilderService.Build(player.Response.First(), pinCode);
            }
            else
            {
                var smitenightExists = await _dbContext.Smitenights.AnyAsync(x => x.PlayerId == playerEntity.Id && !x.EndDate.HasValue, cancellationToken);
                if (smitenightExists)
                {
                    return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.SmitenightAlreadyFound);
                }

                smitenight = _smitenightBuilderService.Build(playerEntity.Id, pinCode);
            }

            _dbContext.Add(smitenight);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.Success, _mapper.Map<SmitenightDto>(smitenight));
        }

        public async Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(string playerName, string? pinCode, CancellationToken cancellationToken = default)
        {
            var playerIdRequest = new PlayerIdByNameRequest(playerName);
            var playerIdResponse = await _retrievePlayerClient.GetPlayerIdByPlayerNameAsync(playerIdRequest, cancellationToken);
            if (playerIdResponse?.Response?.Any() != true)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerByPlayerNameNotFoundInSmite);
            }

            var smitePlayerId = playerIdResponse.Response.First().PlayerId;
            var playerHistoryRequest = new MatchHistoryRequest(smitePlayerId.ToString());
            var playerHistoryResponse = await _playerInfoClient.GetMatchHistoryAsync(playerHistoryRequest, cancellationToken);
            if (playerHistoryResponse?.Response?.Any() != true)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.PlayerHistoryNotFoundInSmite);
            }

            var smitenightMatchIds = new List<int>();
            var playerEntityId = await _dbContext.Players.AsNoTracking().Where(x => x.SmiteId == smitePlayerId).Select(x => x.Id).SingleAsync(cancellationToken);
            var smitenight = await _dbContext.Smitenights.Where(x => x.PlayerId == playerEntityId && x.PinCode == pinCode && x.EndDate == null).SingleOrDefaultAsync(cancellationToken);
            if (smitenight == null)
            {
                return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.SmitenightNotFound);
            }

            playerHistoryResponse.Response.ForEach(matchHistory =>
            {
                if (!DateTime.TryParse(matchHistory.MatchTime, out var startTime))
                {
                    return;
                }

                if (startTime >= smitenight.StartDate)
                {
                    smitenightMatchIds.Add(matchHistory.Match);
                }
            });

            var matchEntityIds = new List<int>();
            if (smitenightMatchIds.Count == 1)
            {
                var matchId = await _importMatchService.ImportAsync(smitenightMatchIds.Single(), cancellationToken);
                if (matchId.HasValue)
                {
                    matchEntityIds.Add(matchId.Value);
                }
            }
            else
            {
                const int batchSize = 5;
                var totalCallsToApi = (smitenightMatchIds.Count - 1) / batchSize + 1;
                for (var i = 0; i < totalCallsToApi; i++)
                {
                    var currentBatch = smitenightMatchIds.Skip(i * batchSize).Take(batchSize).ToList();
                    var matchIds = await _importMatchService.ImportAsync(currentBatch, cancellationToken);
                    if (matchIds.Any())
                    {
                        matchEntityIds.AddRange(matchIds);
                    }
                }
            }

            smitenight.EndDate = _clock.Now();
            var smitenightMatches = matchEntityIds.Select(matchEntityId => new SmitenightMatch {MatchId = matchEntityId, SmitenightId = smitenight.Id}).ToList();
            _dbContext.SmitenightMatches.AddRange(smitenightMatches);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ServerResponseDto<SmitenightDto>(StatusCodeEnum.Success, _mapper.Map<SmitenightDto>(smitenight));
        }
    }
}
