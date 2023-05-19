using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Models.Items;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Builders;

public interface IItemPurchaseBuilderService
{
    Task<List<ItemPurchase>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default);
}