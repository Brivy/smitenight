using Microsoft.Extensions.Logging;
using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

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
            var godChecksumsList = await _maintainGodsService.GetGodChecksumsAsync(cancellationToken);
            var gods = await _godSmiteClient.GetGodsAsync(LanguageCode.English, cancellationToken);
            if (cancellationToken.IsCancellationRequested) return;

            foreach (var god in gods)
            {
                var checksums = godChecksumsList.SingleOrDefault(x => x.GodSmiteId == god.Id);
                if (checksums == null)
                {
                    await CreateNewGodAsync(god, cancellationToken);
                    continue;
                }

                var newGodId = await _maintainGodsService.MaintainGodAsync(god, checksums.GodChecksum, cancellationToken);
                var godUpdated = newGodId.HasValue;
                var godId = newGodId ?? checksums.GodId;

                var abilityDictionary = new Dictionary<string, AbilityDetailsDto> { { checksums.Ability1Checksum, god.AbilityDetails1 }, { checksums.Ability2Checksum, god.AbilityDetails2 }, { checksums.Ability3Checksum, god.AbilityDetails3 }, { checksums.Ability4Checksum, god.AbilityDetails4 }, { checksums.Ability5Checksum, god.AbilityDetails5 } };
                await _maintainGodsService.MaintainAbilitiesAsync(godId, godUpdated, abilityDictionary, cancellationToken);
                await _maintainGodsService.MaintainBasicAttacksAsync(godId, godUpdated, god.BasicAttack.ItemDescription.MenuItems, checksums.BasicAttackChecksum, cancellationToken);

                var godSkins = await _godSmiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
                await _maintainGodsService.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums.GodSkinChecksums, cancellationToken);
            }
        }

        public async Task CreateNewGodAsync(GodDto god, CancellationToken cancellationToken = default)
        {
            var createdGodId = await _maintainGodsService.CreateGodAsync(god, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails1, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails2, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails3, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails4, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails5, cancellationToken);
            await _maintainGodsService.CreateBasicAttacksAsync(createdGodId, god.BasicAttack.ItemDescription.MenuItems, cancellationToken);

            var godSkins = await _godSmiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
            foreach (var godSkin in godSkins)
            {
                await _maintainGodsService.CreateGodSkinAsync(createdGodId, godSkin, cancellationToken);
            }
        }
    }
}
