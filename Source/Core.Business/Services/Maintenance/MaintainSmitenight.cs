using Smitenight.Application.Core.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;

namespace Smitenight.Application.Core.Business.Services.Maintenance;

internal class MaintainSmitenight(
    IMaintainItemsService maintainItemsService,
    IMaintainGodsService maintainGodsService,
    IMaintainPatchesService maintainPatchesService,
    ISmiteClient smiteClient) : IMaintainSmitenight
{
    private readonly IMaintainItemsService _maintainItemsService = maintainItemsService;
    private readonly IMaintainGodsService _maintainGodsService = maintainGodsService;
    private readonly IMaintainPatchesService _maintainPatchesService = maintainPatchesService;
    private readonly ISmiteClient _smiteClient = smiteClient;

    public async Task MaintainPatchesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<HirezServerStatusDto> serverStatus = await _smiteClient.GetHirezServerStatusAsync(cancellationToken);
        string currentPatch = serverStatus.First().Version;
        await _maintainPatchesService.MaintainPatchAsync(currentPatch, cancellationToken);
    }

    public async Task MaintainItemsAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<ItemChecksumsDto> itemChecksums = await _maintainItemsService.GetItemChecksumsAsync(cancellationToken);
        IEnumerable<ItemDto> items = await _smiteClient.GetItemsAsync(LanguageCode.English, cancellationToken);
        if (cancellationToken.IsCancellationRequested) return;

        var relinkNeededSmiteIds = new List<int>();
        foreach (ItemDto item in items)
        {
            ItemChecksumsDto? checksum = itemChecksums.SingleOrDefault(x => x.SmiteItemId == item.ItemId);
            int? itemId = checksum == null
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
        IEnumerable<GodChecksumsDto> godChecksums = await _maintainGodsService.GetGodChecksumsAsync(cancellationToken);
        IEnumerable<GodDto> gods = await _smiteClient.GetGodsAsync(LanguageCode.English, cancellationToken);
        if (cancellationToken.IsCancellationRequested) return;

        foreach (GodDto god in gods)
        {
            GodChecksumsDto? checksums = godChecksums.SingleOrDefault(x => x.SmiteGodId == god.Id);
            if (checksums == null)
            {
                await CreateNewGodAsync(god, cancellationToken);
                continue;
            }

            int? newGodId = await _maintainGodsService.MaintainGodAsync(god, checksums.GodChecksum, cancellationToken);
            bool godUpdated = newGodId.HasValue;
            int godId = newGodId ?? checksums.GodId;

            var abilityDictionary = new Dictionary<string, AbilityDetailsDto> { { checksums.Ability1Checksum, god.AbilityDetails1 }, { checksums.Ability2Checksum, god.AbilityDetails2 }, { checksums.Ability3Checksum, god.AbilityDetails3 }, { checksums.Ability4Checksum, god.AbilityDetails4 }, { checksums.Ability5Checksum, god.AbilityDetails5 } };
            await _maintainGodsService.MaintainAbilitiesAsync(godId, godUpdated, abilityDictionary, cancellationToken);

            IEnumerable<GodSkinDto> godSkins = await _smiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
            await _maintainGodsService.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums.GodSkinChecksums, cancellationToken);
        }
    }

    private async Task CreateNewGodAsync(GodDto god, CancellationToken cancellationToken = default)
    {
        int createdGodId = await _maintainGodsService.CreateGodAsync(god, cancellationToken);
        await _maintainGodsService.CreateAbilityAsync(createdGodId, god.AbilityDetails1, cancellationToken);
        await _maintainGodsService.CreateAbilityAsync(createdGodId, god.AbilityDetails2, cancellationToken);
        await _maintainGodsService.CreateAbilityAsync(createdGodId, god.AbilityDetails3, cancellationToken);
        await _maintainGodsService.CreateAbilityAsync(createdGodId, god.AbilityDetails4, cancellationToken);
        await _maintainGodsService.CreateAbilityAsync(createdGodId, god.AbilityDetails5, cancellationToken);

        IEnumerable<GodSkinDto> godSkins = await _smiteClient.GetGodSkinsAsync(god.Id, LanguageCode.English, cancellationToken);
        foreach (GodSkinDto godSkin in godSkins)
        {
            await _maintainGodsService.CreateGodSkinAsync(createdGodId, godSkin, cancellationToken);
        }
    }
}
