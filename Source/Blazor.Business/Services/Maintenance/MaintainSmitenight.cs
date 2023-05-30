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
        private readonly ISmiteClient _smiteClient;

        public MaintainSmitenight(
            IMaintainItemsService maintainItemsService,
            IMaintainGodsService maintainGodsService,
            ISmiteClient smiteClient)
        {
            _maintainItemsService = maintainItemsService;
            _maintainGodsService = maintainGodsService;
            _smiteClient = smiteClient;
        }

        public async Task MaintainItemsAsync(CancellationToken cancellationToken = default)
        {
            var itemChecksums = await _maintainItemsService.GetItemChecksumsAsync(cancellationToken);
            var items = await _smiteClient.GetItemsAsync(LanguageCode.English, cancellationToken);
            if (cancellationToken.IsCancellationRequested) return;

            var relinkNeededSmiteIds = new List<int>();
            foreach (var item in items)
            {
                var checksum = itemChecksums.SingleOrDefault(x => x.SmiteItemId == item.ItemId);
                var itemId = checksum == null
                    ? await _maintainItemsService.CreateItemAsync(item, cancellationToken)
                    : await _maintainItemsService.MaintainItemAsync(item, checksum.Checksum, cancellationToken);

                if (itemId.HasValue)
                {
                    relinkNeededSmiteIds.Add(itemId.Value);
                }
            }

            var sortedItems = items.Where(x => x.Type == ItemConstants.ItemType).ToList();
            var sortedActives = items.Where(x => x.Type == ItemConstants.ActiveItemType).ToList();
            await _maintainItemsService.LinkItemsAsync(sortedItems, relinkNeededSmiteIds, cancellationToken);
            await _maintainItemsService.LinkActivesAsync(sortedActives, relinkNeededSmiteIds, cancellationToken);
        }

        public async Task MaintainGodsAsync(CancellationToken cancellationToken = default)
        {
            var godChecksums = await _maintainGodsService.GetGodChecksumsAsync(cancellationToken);
            var gods = await _smiteClient.GetGodsAsync(LanguageCode.English, cancellationToken);
            if (cancellationToken.IsCancellationRequested) return;

            foreach (var god in gods)
            {
                var checksums = godChecksums.SingleOrDefault(x => x.SmiteGodId == god.Id);
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

                var godSkins = await _smiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
                await _maintainGodsService.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums.GodSkinChecksums, cancellationToken);
            }
        }

        private async Task CreateNewGodAsync(GodDto god, CancellationToken cancellationToken = default)
        {
            var createdGodId = await _maintainGodsService.CreateGodAsync(god, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails1, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails2, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails3, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails4, cancellationToken);
            await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails5, cancellationToken);

            var godSkins = await _smiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
            foreach (var godSkin in godSkins)
            {
                await _maintainGodsService.CreateGodSkinAsync(createdGodId, godSkin, cancellationToken);
            }
        }
    }
}
