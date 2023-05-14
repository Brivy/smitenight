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
        private readonly IMaintenanceService _maintenanceService;
        private readonly IItemSmiteClient _itemSmiteClient;
        private readonly IGodSmiteClient _godSmiteClient;
        private readonly ILogger<MaintainSmitenight> _logger;

        public MaintainSmitenight(
            IMaintainItemsService maintainItemsService,
            IMaintainGodsService maintainGodsService,
            IMaintenanceService maintenanceService,
            IItemSmiteClient itemSmiteClient,
            IGodSmiteClient godSmiteClient,
            ILogger<MaintainSmitenight> logger)
        {
            _maintainItemsService = maintainItemsService;
            _maintainGodsService = maintainGodsService;
            _maintenanceService = maintenanceService;
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

            try
            {
                foreach (var god in gods)
                {

                    var checksums = godChecksumsList.SingleOrDefault(x => x.GodSmiteId == god.Id);
                    if (checksums == null)
                    {
                        await CreateNewGodAsync(god, cancellationToken);
                        continue;
                    }

                    var godUpdated = false;
                    var createdGodId = checksums.GodId;
                    if (IsChecksumDifferent(checksums.GodChecksum, god))
                    {
                        createdGodId = await _maintainGodsService.CreateGodAsync(god, cancellationToken);
                        godUpdated = true;
                    }

                    // Checksum every ability and create a new one if it's different
                    var abilityDetails = new List<AbilityDetailsDto> { god.AbilityDetails1, god.AbilityDetails2, god.AbilityDetails3, god.AbilityDetails4, god.AbilityDetails5 };
                    var abilityChecksums = new List<string> { checksums.Ability1Checksum, checksums.Ability2Checksum, checksums.Ability3Checksum, checksums.Ability4Checksum, checksums.Ability5Checksum };
                    var abilityIds = new List<int> { god.AbilityId1, god.AbilityId2, god.AbilityId3, god.AbilityId4, god.AbilityId5 };
                    for (var i = 0; i < abilityDetails.Count; i++)
                    {
                        if (IsChecksumDifferent(abilityChecksums[i], abilityDetails[i]))
                        {
                            await _maintainGodsService.CreateAbility(createdGodId, abilityDetails[i], cancellationToken);
                            abilityIds.Remove(abilityIds[i]);
                        }
                    }

                    // TODO: figure this one out
                    if (IsChecksumDifferent(checksums.BasicAttackDescriptionChecksum, god.BasicAttack.ItemDescription.MenuItems))
                    {
                        await _maintainGodsService.CreateBasicAttackDescriptionsAsync(createdGodId, god.BasicAttack.ItemDescription.MenuItems, cancellationToken);
                    }

                    // Update the remaining abilities if the god was updated
                    if (godUpdated && abilityIds.Any())
                    {
                        await _maintainGodsService.UpdateGodRelationAsync(createdGodId, abilityIds, cancellationToken);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Maintaining gods ended up in an exception");
            }
        }

        private bool IsChecksumDifferent<TCompare>(string checksum, TCompare comparisonObject)
        {
            return checksum != _maintenanceService.CalculateChecksum(comparisonObject);
        }


        public async Task CreateNewGodAsync(GodDto god, CancellationToken cancellationToken = default)
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
}
