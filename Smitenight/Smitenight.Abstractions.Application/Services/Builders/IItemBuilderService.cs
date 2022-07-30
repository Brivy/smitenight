using Smitenight.Domain.Clients.SmiteClient.Responses.ItemResponses;
using Smitenight.Domain.Models.Items;

namespace Smitenight.Abstractions.Application.Services.Builders;

public interface IItemBuilderService
{
    Item BuildItem(ItemsResponse item);

    Consumable BuildConsumable(ItemsResponse item);

    Active BuildActive(ItemsResponse item);
}