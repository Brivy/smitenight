using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IItemPurchaseBuilderService
{
    Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
}