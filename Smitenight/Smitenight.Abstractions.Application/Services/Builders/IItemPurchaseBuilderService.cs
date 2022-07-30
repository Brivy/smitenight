using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Models.Items;

namespace Smitenight.Abstractions.Application.Services.Builders;

public interface IItemPurchaseBuilderService
{
    Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default);
}