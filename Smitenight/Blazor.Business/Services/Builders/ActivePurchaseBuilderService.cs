using Microsoft.EntityFrameworkCore;
using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.EntityFramework;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;

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
            activeIdList.RemoveAll(x => x == SmiteConstants.EmptyResponse);
            if (!activeIdList.Any())
            {
                return activePurchases;
            }

            var actives = await _dbContext.Actives.AsNoTracking().Where(x => activeIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetailsResponse.ActiveId1 != SmiteConstants.EmptyResponse)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ActiveId1)?.Id ?? MatchConstants.DefaultActiveId, ActivePurchaseOrder = ActivePurchaseOrderEnum.FirstActive });
            }
            if (matchDetailsResponse.ActiveId2 != SmiteConstants.EmptyResponse)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ActiveId2)?.Id ?? MatchConstants.DefaultActiveId, ActivePurchaseOrder = ActivePurchaseOrderEnum.SecondActive });
            }

            return activePurchases;
        }
    }
}
