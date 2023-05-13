using Microsoft.Extensions.Logging;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainSmitenight : IMaintainSmitenight
    {
        private readonly IMaintainItemsService _maintainItemsService;
        private readonly IMaintainGodsService _maintainGodsService;
        private readonly IItemSmiteClient _itemSmiteClient;
        private readonly IGodSmiteClient _godSmiteClient;
        private readonly ILogger<MaintainSmitenight> _logger;

        public MaintainSmitenight(
            IMaintainItemsService maintainItemsService,
            IMaintainGodsService maintainGodsService,
            IItemSmiteClient itemSmiteClient,
            IGodSmiteClient godSmiteClient,
            ILogger<MaintainSmitenight> logger)
        {
            _maintainItemsService = maintainItemsService;
            _maintainGodsService = maintainGodsService;
            _itemSmiteClient = itemSmiteClient;
            _godSmiteClient = godSmiteClient;
            _logger = logger;
        }

        public async Task MaintainItemsAsync(CancellationToken cancellationToken = default)
        {
            var items = await _itemSmiteClient.GetItemsAsync(LanguageCode.English, cancellationToken);
            if (cancellationToken.IsCancellationRequested) return;

            try
            {
                foreach (var item in items)
                {
                    switch (item.Type)
                    {
                        case ItemConstants.ItemType:
                            await _maintainItemsService.CreateItemAsync(item, cancellationToken);
                            break;
                        case ItemConstants.ConsumableItemType:
                            await _maintainItemsService.CreateConsumableAsync(item, cancellationToken);
                            break;
                        case ItemConstants.ActiveItemType:
                            await _maintainItemsService.CreateActiveAsync(item, cancellationToken);
                            break;
                    }
                }

                var sortedItems = items.Where(x => x.Type == ItemConstants.ItemType).ToList();
                var sortedActives = items.Where(x => x.Type == ItemConstants.ActiveItemType).ToList();
                await _maintainItemsService.LinkItemsAsync(sortedItems, cancellationToken);
                await _maintainItemsService.LinkActivesAsync(sortedActives, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Maintaining items ended up in an exception");
            }
        }

        public async Task MaintainGodsAsync(CancellationToken cancellationToken = default)
        {
            var gods = await _godSmiteClient.GetGodsAsync(LanguageCode.English, cancellationToken);
            if (cancellationToken.IsCancellationRequested) return;

            try
            {
                foreach (var god in gods)
                {
                    var createdGodId = await _maintainGodsService.CreateGodAsync(god, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails1, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails2, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails3, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails4, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails5, cancellationToken);
                    await _maintainGodsService.CreateBasicAttackDescriptionsAsync(createdGodId, god.BasicAttack.ItemDescription.MenuItems, cancellationToken);

                    var godSkins = await _godSmiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
                    await _maintainGodsService.CreateGodSkinsAsync(createdGodId, godSkins, cancellationToken);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Maintaining gods ended up in an exception");
            }
        }
    }
}
