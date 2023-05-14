using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance
{
    public interface IMaintainGodsService
    {
        Task<IEnumerable<GodChecksumsDto>> GetGodChecksumsAsync(CancellationToken cancellationToken = default);
        Task CreateAbility(int createdGodId, AbilityDetailsDto ability, CancellationToken cancellationToken = default);
        Task UpdateGodRelationAsync(int createGodId, IEnumerable<int> abilityIds, CancellationToken cancellationToken = default);
        Task CreateBasicAttackDescriptionsAsync(int createdGodId, IEnumerable<BasicAttackItemDto> basicAttacks, CancellationToken cancellationToken = default);
        Task<int> CreateGodAsync(GodDto god, CancellationToken cancellationToken = default);
        Task CreateGodSkinsAsync(int createdGodId, IEnumerable<GodSkinDto> godSkins, CancellationToken cancellationToken = default);
    }
}