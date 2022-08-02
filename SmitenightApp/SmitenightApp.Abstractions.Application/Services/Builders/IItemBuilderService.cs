using SmitenightApp.Domain.Clients.SmiteClient.Responses.ItemResponses;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IItemBuilderService
{
    Item BuildItem(ItemsResponse itemResponse);

    Consumable BuildConsumable(ItemsResponse consumableResponse);

    Active BuildActive(ItemsResponse activeResponse);
}