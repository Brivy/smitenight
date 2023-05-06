using Microsoft.EntityFrameworkCore;
using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Constants.SmiteClient.Responses;
using Smitenight.Domain.Models.Enums.Items;
using Smitenight.Domain.Models.Models.Items;
using Smitenight.Persistence.Data.EntityFramework;

namespace Smitenight.Application.Blazor.Business.Services.Builders
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
