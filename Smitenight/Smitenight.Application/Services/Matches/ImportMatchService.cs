using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Builders;
using Smitenight.Abstractions.Application.Services.Matches;
using Smitenight.Abstractions.Application.Services.System;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Constants.SmiteClient.Responses;
using Smitenight.Domain.Models.Matches;
using Smitenight.Persistence;

namespace Smitenight.Application.Services.Matches
{
    public class ImportMatchService : IImportMatchService
    {
        private readonly ISmiteSessionService _smiteSessionService;
        private readonly IActivePurchaseBuilderService _activePurchaseBuilderService;
        private readonly IGodBanBuilderService _godBanBuilderService;
        private readonly IItemPurchaseBuilderService _itemPurchaseBuilderService;
        private readonly IMatchBuilderService _matchBuilderService;
        private readonly IMatchDetailBuilderService _matchDetailBuilderService;
        private readonly IPlayerBuilderService _playerBuilderService;
        private readonly IMatchInfoClient _matchInfoClient;
        private readonly SmitenightDbContext _dbContext;

        public ImportMatchService(
            ISmiteSessionService smiteSessionService,
            IActivePurchaseBuilderService activePurchaseBuilderService,
            IGodBanBuilderService godBanBuilderService,
            IItemPurchaseBuilderService itemPurchaseBuilderService,
            IMatchBuilderService matchBuilderService,
            IMatchDetailBuilderService matchDetailBuilderService,
            IPlayerBuilderService playerBuilderService,
            IMatchInfoClient matchInfoClient,
            SmitenightDbContext dbContext)
        {
            _smiteSessionService = smiteSessionService;
            _activePurchaseBuilderService = activePurchaseBuilderService;
            _godBanBuilderService = godBanBuilderService;
            _itemPurchaseBuilderService = itemPurchaseBuilderService;
            _matchBuilderService = matchBuilderService;
            _matchDetailBuilderService = matchDetailBuilderService;
            _playerBuilderService = playerBuilderService;
            _matchInfoClient = matchInfoClient;
            _dbContext = dbContext;
        }

        public async Task ImportAsync(int smiteMatchId, CancellationToken cancellationToken = default)
        {
            var matchAlreadyExists = await _dbContext.Matches.AnyAsync(x => x.SmiteId == smiteMatchId, cancellationToken);
            if (matchAlreadyExists)
            {
                return;
            }

            var sessionId = await _smiteSessionService.GetSessionIdAsync(cancellationToken);
            if (string.IsNullOrEmpty(sessionId))
            {
                return;
            }

            var matchDetailsRequest = new MatchDetailsRequest(sessionId, smiteMatchId);
            var matchDetailsResponse = await _matchInfoClient.GetMatchDetailsAsync(matchDetailsRequest, cancellationToken);
            if (matchDetailsResponse?.Response?.Any() != true)
            {
                return;
            }

            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var singleMatchDetails = matchDetailsResponse.Response.First();
                var matchEntity = _matchBuilderService.Build(singleMatchDetails);
                matchEntity.GodBans = await _godBanBuilderService.BuildAsync(singleMatchDetails, cancellationToken);

                foreach (var matchDetails in matchDetailsResponse.Response)
                {
                    var matchDetailsEntity = _matchDetailBuilderService.Build(matchDetails);

                    // Attach the given god
                    var god = await _dbContext.Gods.AsNoTracking().Include(x => x.GodSkins).SingleOrDefaultAsync(x => x.SmiteId == matchDetails.GodId, cancellationToken);
                    matchDetailsEntity.GodId = god?.Id ?? MatchResponseConstants.DefaultGodId;
                    matchDetailsEntity.GodSkinId = god?.GodSkins.SingleOrDefault(x => x.SmiteId == matchDetails.SkinId || x.SecondarySmiteId == matchDetails.SkinId)?.Id ?? MatchResponseConstants.DefaultGodSkinId;

                    // Attach purchased active and item entities
                    matchDetailsEntity.ActivePurchases = await _activePurchaseBuilderService.BuildAsync(matchDetails, cancellationToken);
                    matchDetailsEntity.ItemPurchases = await _itemPurchaseBuilderService.BuildAsync(matchDetails, cancellationToken);

                    // Attach player (and update if already exists)
                    if (!string.IsNullOrWhiteSpace(matchDetails.PlayerId) && matchDetails.PlayerId != MatchResponseConstants.AnonymousPlayerId)
                    {
                        await ProcessPlayerAsync(matchDetails, matchDetailsEntity, cancellationToken);
                    }
                    else
                    {
                        await ProcessAnonymousPlayerAsync(matchDetails, matchDetailsEntity, cancellationToken);
                    }

                    matchEntity.MatchDetails.Add(matchDetailsEntity);
                }

                _dbContext.Matches.Add(matchEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region Processing

        public async Task ProcessPlayerAsync(MatchDetailsResponse matchDetails, MatchDetail matchDetailsEntity, CancellationToken cancellationToken = default)
        {
            if (!int.TryParse(matchDetails.PlayerId, out var parsedPlayerId))
            {
                await ProcessAnonymousPlayerAsync(matchDetails, matchDetailsEntity, cancellationToken);
                return;
            }

            var existingPlayer = await _dbContext.Players.AsNoTracking().SingleOrDefaultAsync(x => x.SmiteId == parsedPlayerId, cancellationToken);
            if (existingPlayer == null)
            {
                var player = _playerBuilderService.Build(matchDetails);
                matchDetailsEntity.Player = player;
            }
            else if (existingPlayer.LastSynchronizedMatchId < matchDetails.Match)
            {
                var player = _playerBuilderService.Build(matchDetails);
                player.Id = existingPlayer.Id;
                matchDetailsEntity.PlayerId = existingPlayer.Id;
                matchDetailsEntity.Player = player;
                _dbContext.Players.Update(player);
            }
            else
            {
                matchDetailsEntity.PlayerId = existingPlayer.Id;
            }
        }

        public async Task ProcessAnonymousPlayerAsync(MatchDetailsResponse matchDetails, MatchDetail matchDetailsEntity, CancellationToken cancellationToken = default)
        {
            var existingPlayer = await _dbContext.Players.AsNoTracking().SingleOrDefaultAsync(x => x.Level == matchDetails.AccountLevel && x.MasteryLevel == matchDetails.MasteryLevel, cancellationToken);
            if (existingPlayer == null)
            {
                var player = _playerBuilderService.BuildAnonymous(matchDetails);
                matchDetailsEntity.Player = player;
            }
            else
            {
                matchDetailsEntity.PlayerId = existingPlayer.Id;
            }
        }

        #endregion
    }
}
