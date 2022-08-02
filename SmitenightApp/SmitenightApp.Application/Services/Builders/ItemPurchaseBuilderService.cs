using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Items;
using SmitenightApp.Domain.Models.Items;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Builders
{
    public class ItemPurchaseBuilderService : IItemPurchaseBuilderService
    {
        private readonly SmitenightDbContext _dbContext;

        public ItemPurchaseBuilderService(SmitenightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default)
        {
            var itemPurchases = new List<ItemPurchase>();
            var itemIdList = new List<int> { matchDetailsResponse.ItemId1, matchDetailsResponse.ItemId2, matchDetailsResponse.ItemId3, matchDetailsResponse.ItemId4, matchDetailsResponse.ItemId5, matchDetailsResponse.ItemId6 };
            itemIdList.RemoveAll(x => x == ResponseConstants.EmptyResponse);
            if (!itemIdList.Any())
            {
                return itemPurchases;
            }

            var items = await _dbContext.Items.AsNoTracking().Where(x => itemIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetailsResponse.ItemId1 != ResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId1)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FirstItem });
            }
            if (matchDetailsResponse.ItemId2 != ResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId2)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.SecondItem });
            }
            if (matchDetailsResponse.ItemId3 != ResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId3)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.ThirdItem });
            }
            if (matchDetailsResponse.ItemId4 != ResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId4)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FourthItem });
            }
            if (matchDetailsResponse.ItemId5 != ResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId5)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FifthItem });
            }
            if (matchDetailsResponse.ItemId6 != ResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.ItemId6)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.SixthItem });
            }

            return itemPurchases;
        }
    }
}
