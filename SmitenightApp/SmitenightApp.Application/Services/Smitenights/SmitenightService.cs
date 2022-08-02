using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Common;
using SmitenightApp.Abstractions.Application.Services.Matches;
using SmitenightApp.Abstractions.Application.Services.Smitenights;
using SmitenightApp.Abstractions.Application.Services.System;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.PlayerRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.RetrievePlayerRequests;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Models.Smitenights;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Smitenights
{
    public class SmitenightService : ISmitenightService
    {
        private readonly ISmiteSessionService _smiteSessionService;
        private readonly IPlayerInfoClient _playerInfoClient;
        private readonly IRetrievePlayerClient _retrievePlayerClient;
        private readonly IImportMatchService _importMatchService;
        private readonly ISmitenightBuilderService _smitenightBuilderService;
        private readonly IClock _clock;
        private readonly SmitenightDbContext _dbContext;

        public SmitenightService(
            ISmiteSessionService smiteSessionService,
            IPlayerInfoClient playerInfoClient,
            IRetrievePlayerClient retrievePlayerClient,
            IImportMatchService importMatchService,
            ISmitenightBuilderService smitenightBuilderService,
            IClock clock,
            SmitenightDbContext dbContext)
        {
            _smiteSessionService = smiteSessionService;
            _playerInfoClient = playerInfoClient;
            _retrievePlayerClient = retrievePlayerClient;
            _importMatchService = importMatchService;
            _smitenightBuilderService = smitenightBuilderService;
            _clock = clock;
            _dbContext = dbContext;
        }

        public async Task StartSmitenight(string playerName, CancellationToken cancellationToken = default)
        {
            var sessionId = await _smiteSessionService.GetSessionIdAsync(cancellationToken);
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                return;
            }

            var playerIdRequest = new PlayerIdByNameRequest(sessionId, playerName);
            var playerIdResponse = await _retrievePlayerClient.GetPlayerIdByPlayerNameAsync(playerIdRequest, cancellationToken);
            if (playerIdResponse?.Response?.Any() != true)
            {
                return;
            }

            var smitePlayer = playerIdResponse.Response.First();
            if (smitePlayer.PrivacyFlag == ResponseConstants.Yes)
            {
                return;
            }

            Smitenight smitenight;
            var playerEntity = await _dbContext.Players.AsNoTracking().Where(x => x.SmiteId == smitePlayer.PlayerId).SingleOrDefaultAsync(cancellationToken);
            if (playerEntity == null)
            {
                var playerRequest = new PlayerWithoutPortalRequest(sessionId, smitePlayer.PlayerId.ToString());
                var player = await _retrievePlayerClient.GetPlayerWithoutPortalAsync(playerRequest, cancellationToken);
                if (player?.Response?.Any() != true || player.Response.First().Id == ResponseConstants.AnonymousPlayerIntId)
                {
                    return;
                }

                smitenight = _smitenightBuilderService.Build(player.Response.First());
            }
            else
            {
                var smitenightExists = await _dbContext.Smitenights.AnyAsync(x => x.PlayerId == playerEntity.Id && !x.EndDate.HasValue, cancellationToken);
                if (smitenightExists)
                {
                    return;
                }

                smitenight = _smitenightBuilderService.Build(playerEntity.Id);
            }

            _dbContext.Add(smitenight);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task EndSmitenight(string playerName, CancellationToken cancellationToken = default)
        {
            var sessionId = await _smiteSessionService.GetSessionIdAsync(cancellationToken);
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                return;
            }

            var playerIdRequest = new PlayerIdByNameRequest(sessionId, playerName);
            var playerIdResponse = await _retrievePlayerClient.GetPlayerIdByPlayerNameAsync(playerIdRequest, cancellationToken);
            if (playerIdResponse?.Response?.Any() != true)
            {
                return;
            }

            var smitePlayerId = playerIdResponse.Response.First().PlayerId;
            var playerHistoryRequest = new MatchHistoryRequest(sessionId, smitePlayerId.ToString());
            var playerHistoryResponse = await _playerInfoClient.GetMatchHistoryAsync(playerHistoryRequest, cancellationToken);
            if (playerHistoryResponse?.Response?.Any() != true)
            {
                return;
            }

            var smitenightMatchIds = new List<int>();
            var playerEntityId = await _dbContext.Players.AsNoTracking().Where(x => x.SmiteId == smitePlayerId).Select(x => x.Id).SingleAsync(cancellationToken);
            var smitenight = await _dbContext.Smitenights.Where(x => x.PlayerId == playerEntityId && x.EndDate == null).SingleAsync(cancellationToken);
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
        }
    }
}
