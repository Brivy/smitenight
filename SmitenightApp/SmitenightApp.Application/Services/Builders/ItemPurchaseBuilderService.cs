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

        public async Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default)
        {
            var itemPurchases = new List<ItemPurchase>();
            var itemIdList = new List<int> { matchDetails.ItemId1, matchDetails.ItemId2, matchDetails.ItemId3, matchDetails.ItemId4, matchDetails.ItemId5, matchDetails.ItemId6 };
            itemIdList.RemoveAll(x => x == MatchResponseConstants.EmptyResponse);
            if (!itemIdList.Any())
            {
                return itemPurchases;
            }

            var items = await _dbContext.Items.AsNoTracking().Where(x => itemIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetails.ItemId1 != MatchResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId1)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FirstItem });
            }
            if (matchDetails.ItemId2 != MatchResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId2)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.SecondItem });
            }
            if (matchDetails.ItemId3 != MatchResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId3)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.ThirdItem });
            }
            if (matchDetails.ItemId4 != MatchResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId4)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FourthItem });
            }
            if (matchDetails.ItemId5 != MatchResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId5)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.FifthItem });
            }
            if (matchDetails.ItemId6 != MatchResponseConstants.EmptyResponse)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId6)?.Id ?? MatchResponseConstants.DefaultItemId, ItemPurchaseOrder = ItemPurchaseOrderEnum.SixthItem });
            }

            return itemPurchases;
        }
    }
}
