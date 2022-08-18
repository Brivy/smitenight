using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Matches;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.MatchRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Models.Matches;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Matches
{
    public class ImportMatchService : IImportMatchService
    {
        private readonly IActivePurchaseBuilderService _activePurchaseBuilderService;
        private readonly IGodBanBuilderService _godBanBuilderService;
        private readonly IItemPurchaseBuilderService _itemPurchaseBuilderService;
        private readonly IMatchBuilderService _matchBuilderService;
        private readonly IMatchDetailBuilderService _matchDetailBuilderService;
        private readonly IPlayerBuilderService _playerBuilderService;
        private readonly IMatchInfoClient _matchInfoClient;
        private readonly SmitenightDbContext _dbContext;

        public ImportMatchService(
            IActivePurchaseBuilderService activePurchaseBuilderService,
            IGodBanBuilderService godBanBuilderService,
            IItemPurchaseBuilderService itemPurchaseBuilderService,
            IMatchBuilderService matchBuilderService,
            IMatchDetailBuilderService matchDetailBuilderService,
            IPlayerBuilderService playerBuilderService,
            IMatchInfoClient matchInfoClient,
            SmitenightDbContext dbContext)
        {
            _activePurchaseBuilderService = activePurchaseBuilderService;
            _godBanBuilderService = godBanBuilderService;
            _itemPurchaseBuilderService = itemPurchaseBuilderService;
            _matchBuilderService = matchBuilderService;
            _matchDetailBuilderService = matchDetailBuilderService;
            _playerBuilderService = playerBuilderService;
            _matchInfoClient = matchInfoClient;
            _dbContext = dbContext;
        }

        public async Task<int?> ImportAsync(int smiteMatchId, CancellationToken cancellationToken = default)
        {
            var existingMatch = await _dbContext.Matches.AsNoTracking().Where(x => x.SmiteId == smiteMatchId).SingleOrDefaultAsync(cancellationToken);
            if (existingMatch != null)
            {
                return existingMatch.Id;
            }

            var matchDetailsRequest = new MatchDetailsRequest(smiteMatchId);
            var matchDetailsResponse = await _matchInfoClient.GetMatchDetailsAsync(matchDetailsRequest, cancellationToken);
            if (matchDetailsResponse?.Response?.Any() != true)
            {
                return null;
            }

            return await ProcessImportingMatchAsync(matchDetailsResponse.Response, cancellationToken);
        }

        public async Task<List<int>> ImportAsync(List<int> smiteMatchIds, CancellationToken cancellationToken = default)
        {
            var matchIdList = new List<int>();
            if (!smiteMatchIds.Any())
            {
                return matchIdList;
            }

            var existingMatches = await _dbContext.Matches.AsNoTracking().Where(x => smiteMatchIds.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (existingMatches.Any())
            {
                foreach (var existingMatch in existingMatches)
                {
                    smiteMatchIds.Remove(existingMatch.SmiteId);
                    matchIdList.Add(existingMatch.Id);
                }

                if (!smiteMatchIds.Any())
                {
                    return matchIdList;
                }
            }

            var matchDetailsBatchRequest = new MatchDetailsBatchRequest(smiteMatchIds);
            var matchDetailsBatchResponse = await _matchInfoClient.GetMatchDetailsBatchAsync(matchDetailsBatchRequest, cancellationToken);
            if (matchDetailsBatchResponse?.Response?.Any() != true)
            {
                return matchIdList;
            }


            foreach (var matchDetailsResponse in matchDetailsBatchResponse.Response.OrderByDescending(x => x.Match).GroupBy(x => x.Match))
            {
                var matchId = await ProcessImportingMatchAsync(matchDetailsResponse.ToList(), cancellationToken);
                if (matchId.HasValue)
                {
                    matchIdList.Add(matchId.Value);
                }
            }

            return matchIdList;
        }

        #region Processing

        private async Task<int?> ProcessImportingMatchAsync(List<MatchDetailsResponse> matchDetailsResponse, CancellationToken cancellationToken = default)
        {
            int? insertedMatchId = null;
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var singleMatchDetails = matchDetailsResponse.First();
                var matchEntity = _matchBuilderService.Build(singleMatchDetails);
                matchEntity.GodBans = await _godBanBuilderService.BuildAsync(singleMatchDetails, cancellationToken);

                foreach (var matchDetails in matchDetailsResponse)
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
                    if (!string.IsNullOrWhiteSpace(matchDetails.PlayerId) && matchDetails.PlayerId != ResponseConstants.AnonymousPlayerStringId)
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

                insertedMatchId = matchEntity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return insertedMatchId;
        }

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
            else if (!existingPlayer.LastSynchronizedMatchId.HasValue || existingPlayer.LastSynchronizedMatchId < matchDetails.Match)
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
            var existingPlayer = await _dbContext.Players.AsNoTracking().SingleOrDefaultAsync(x => x.PrivacyEnabled && x.Level == matchDetails.AccountLevel && x.MasteryLevel == matchDetails.MasteryLevel, cancellationToken);
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
