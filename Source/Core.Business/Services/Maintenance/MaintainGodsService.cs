using Smitenight.Application.Core.Business.Contracts.Services.Checksums;
using Smitenight.Application.Core.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Services;

namespace Smitenight.Application.Core.Business.Services.Maintenance;

internal class MaintainGodsService(
    IMaintainGodsRepository maintainGodsRepository,
    IChecksumService checksumService,
    IMapperService mapperService) : IMaintainGodsService
{
    private readonly IMaintainGodsRepository _maintainGodsRepository = maintainGodsRepository;
    private readonly IChecksumService _checksumService = checksumService;
    private readonly IMapperService _mapperService = mapperService;

    public async Task<int?> MaintainGodAsync(GodDto god, string checksum, CancellationToken cancellationToken = default)
    {
        // Make sure that we create a clean checksum of an smite god without the abilities interfering
        GodDto strippedGod = god with
        {
            AbilityDetails1 = null!,
            AbilityDetails2 = null!,
            AbilityDetails3 = null!,
            AbilityDetails4 = null!,
            AbilityDetails5 = null!,
            AbilityDescription1 = null!,
            AbilityDescription2 = null!,
            AbilityDescription3 = null!,
            AbilityDescription4 = null!,
            AbilityDescription5 = null!,
        };

        if (!_checksumService.IsChecksumDifferent(checksum, strippedGod))
        {
            return null;
        }

        return await CreateGodAsync(god, cancellationToken);
    }

    public async Task MaintainAbilitiesAsync(int godId, bool godUpdated, Dictionary<string, AbilityDetailsDto> abilityChecksums, CancellationToken cancellationToken = default)
    {
        foreach (KeyValuePair<string, AbilityDetailsDto> abilityChecksum in abilityChecksums)
        {
            if (_checksumService.IsChecksumDifferent(abilityChecksum.Key, abilityChecksum.Value))
            {
                await CreateAbility(godId, abilityChecksum.Value, cancellationToken);
            }
            else if (godUpdated)
            {
                await _maintainGodsRepository.UpdateAbilityRelationAsync(godId, abilityChecksum.Value.Id, cancellationToken);
            }
        }
    }

    public async Task MaintainGodSkinsAsync(int godId, bool godUpdated, IEnumerable<GodSkinDto> godSkins, IEnumerable<string> checksums, CancellationToken cancellationToken = default)
    {
        foreach (GodSkinDto godSkin in godSkins)
        {
            string skinChecksum = _checksumService.CalculateChecksum(godSkin);
            if (!checksums.Any(x => x == skinChecksum))
            {
                await CreateGodSkinAsync(godId, godSkin, cancellationToken);
            }
            else if (godUpdated)
            {
                await _maintainGodsRepository.UpdateGodSkinRelationAsync(godId, godSkin.SkinId1, godSkin.SkinId2, cancellationToken);
            }
        }
    }

    public Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default)
    {
        return _maintainGodsRepository.GetGodChecksumsAsync(cancellationToken);
    }

    public Task<int> CreateGodAsync(GodDto god, CancellationToken cancellationToken = default)
    {
        CreateGodDto createGod = _mapperService.Map<GodDto, CreateGodDto>(god);
        return _maintainGodsRepository.CreateGodAsync(createGod, cancellationToken);
    }

    public Task CreateAbility(int godId, AbilityDetailsDto ability, CancellationToken cancellationToken = default)
    {
        CreateAbilityDto createdAbility = _mapperService.Map<AbilityDetailsDto, CreateAbilityDto>(ability);
        return _maintainGodsRepository.CreateAbilityAsync(godId, createdAbility, cancellationToken);
    }

    public Task CreateGodSkinAsync(int godId, GodSkinDto godSkin, CancellationToken cancellationToken = default)
    {
        CreateGodSkinDto createdGodSkin = _mapperService.Map<GodSkinDto, CreateGodSkinDto>(godSkin);
        return _maintainGodsRepository.CreateGodSkinAsync(godId, createdGodSkin, cancellationToken);
    }
}
