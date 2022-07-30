using SmitenightApp.Domain.Clients.SmiteClient.Responses.ItemResponses;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IItemBuilderService
{
    Item BuildItem(ItemsResponse item);

    Consumable BuildConsumable(ItemsResponse item);

    Active BuildActive(ItemsResponse item);
}