using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Builders;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Constants.SmiteClient.Responses;
using Smitenight.Domain.Enums.Items;
using Smitenight.Domain.Models.Items;
using Smitenight.Persistence;

namespace Smitenight.Application.Services.Builders
{
    public class ActivePurchaseBuilderService : IActivePurchaseBuilderService
    {
        private readonly SmitenightDbContext _dbContext;

        public ActivePurchaseBuilderService(SmitenightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ActivePurchase>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default)
        {
            var activePurchases = new List<ActivePurchase>();
            var activeIdList = new List<int> { matchDetails.ActiveId1, matchDetails.ActiveId2 };
            activeIdList.RemoveAll(x => x == MatchResponseConstants.EmptyResponse);
            if (!activeIdList.Any())
            {
                return activePurchases;
            }

            var actives = await _dbContext.Actives.AsNoTracking().Where(x => activeIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetails.ActiveId1 != MatchResponseConstants.EmptyResponse)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetails.ActiveId1)?.Id ?? MatchResponseConstants.DefaultActiveId, ActivePurchaseOrder = ActivePurchaseOrderEnum.FirstActive });
            }
            if (matchDetails.ActiveId2 != MatchResponseConstants.EmptyResponse)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetails.ActiveId2)?.Id ?? MatchResponseConstants.DefaultActiveId, ActivePurchaseOrder = ActivePurchaseOrderEnum.SecondActive });
            }

            return activePurchases;
        }
    }
}
