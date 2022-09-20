using SmitenightApp.Domain.Clients.ItemClient;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IItemBuilderService
{
    Item BuildItem(ItemsResponse itemResponse);

    Consumable BuildConsumable(ItemsResponse consumableResponse);

    Active BuildActive(ItemsResponse activeResponse);
}