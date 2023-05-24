//using Microsoft.EntityFrameworkCore;
//using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
//using Smitenight.Domain.Models.Clients.MatchClient;
//using Smitenight.Persistence.Data.Contracts.Enums;
//using Smitenight.Persistence.Data.EntityFramework;
//using Smitenight.Persistence.Data.EntityFramework.Entities;
//using Smitenight.Providers.SmiteProvider.Contracts.Constants;

//namespace Smitenight.Application.Blazor.Business.Services.Builders
//{
//    public class ItemPurchaseBuilderService : IItemPurchaseBuilderService
//    {
//        private readonly SmitenightDbContext _dbContext;

//        public ItemPurchaseBuilderService(SmitenightDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default)
//        {
//            var itemPurchases = new List<ItemPurchase>();
//            var itemIdList = new List<int> { matchDetailsResponse.ItemId1, matchDetailsResponse.ItemId2, matchDetailsResponse.ItemId3, matchDetailsResponse.ItemId4, matchDetailsResponse.ItemId5, matchDetailsResponse.ItemId6 };
//            itemIdList.RemoveAll(x => x == SmiteConstants.EmptyResponse);
//            if (!itemIdList.Any())
//            {
//                return itemPurchases;
//            }

//            var items = await _dbContext.Items.AsNoTracking().Where(x => itemIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
//            if (matchDetailsResponse.ItemId1 != SmiteConstants.EmptyResponse)
//            {
//                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId1)?.Id ?? MatchConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FirstItem });
//            }
//            if (matchDetailsResponse.ItemId2 != SmiteConstants.EmptyResponse)
//            {
//                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId2)?.Id ?? MatchConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.SecondItem });
//            }
//            if (matchDetailsResponse.ItemId3 != SmiteConstants.EmptyResponse)
//            {
//                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId3)?.Id ?? MatchConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.ThirdItem });
//            }
//            if (matchDetailsResponse.ItemId4 != SmiteConstants.EmptyResponse)
//            {
//                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId4)?.Id ?? MatchConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FourthItem });
//            }
//            if (matchDetailsResponse.ItemId5 != SmiteConstants.EmptyResponse)
//            {
//                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId5)?.Id ?? MatchConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FifthItem });
//            }
//            if (matchDetailsResponse.ItemId6 != SmiteConstants.EmptyResponse)
//            {
//                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId6)?.Id ?? MatchConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.SixthItem });
//            }

//            return itemPurchases;
//        }
//    }
//}
