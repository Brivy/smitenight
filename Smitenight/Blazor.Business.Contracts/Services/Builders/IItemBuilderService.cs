using Smitenight.Domain.Models.Clients.ItemClient;
using Smitenight.Domain.Models.Models.Items;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Builders;

public interface IItemBuilderService
{
    Item BuildItem(ItemsResponse itemResponse);

    Consumable BuildConsumable(ItemsResponse consumableResponse);

    Active BuildActive(ItemsResponse activeResponse);
}