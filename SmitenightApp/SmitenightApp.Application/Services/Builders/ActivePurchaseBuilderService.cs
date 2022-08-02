using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Models.Items;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Builders
{
    public class ActivePurchaseBuilderService : IActivePurchaseBuilderService
    {
        private readonly SmitenightDbContext _dbContext;

        public ActivePurchaseBuilderService(SmitenightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ActivePurchase>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default)
        {
            var activePurchases = new List<ActivePurchase>();
            var activeIdList = new List<int> { matchDetailsResponse.ActiveId1, matchDetailsResponse.ActiveId2 };
            activeIdList.RemoveAll(x => x == ResponseConstants.EmptyResponse);
            if (!activeIdList.Any())
            {
                return activePurchases;
            }

            var actives = await _dbContext.Actives.AsNoTracking().Where(x => activeIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetailsResponse.ActiveId1 != ResponseConstants.EmptyResponse)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ActiveId1)?.Id ?? MatchResponseConstants.DefaultActiveId, ActivePurchaseOrder = ActivePurchaseOrderEnum.FirstActive });
            }
            if (matchDetailsResponse.ActiveId2 != ResponseConstants.EmptyResponse)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ActiveId2)?.Id ?? MatchResponseConstants.DefaultActiveId, ActivePurchaseOrder = ActivePurchaseOrderEnum.SecondActive });
            }

            return activePurchases;
        }
    }
}
