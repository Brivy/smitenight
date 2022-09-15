using SmitenightApp.Domain.Clients.MatchClient;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IItemPurchaseBuilderService
{
    Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default);
}