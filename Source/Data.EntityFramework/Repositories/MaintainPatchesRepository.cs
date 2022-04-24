using Microsoft.EntityFrameworkCore;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Services;

namespace Smitenight.Persistence.Data.EntityFramework.Repositories;

public class MaintainPatchesRepository(
    SmitenightDbContext smitenightDbContext,
    IMapperService mapperService) : IMaintainPatchesRepository
{
    private readonly SmitenightDbContext _dbContext = smitenightDbContext;
    private readonly IMapperService _mapperService = mapperService;

    public Task<int> GetLatestPatchAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Patches
            .OrderByDescending(x => x.ReleaseDate)
            .Select(x => x.Id)
            .FirstAsync(cancellationToken);
    }


    public async Task<bool> IsNewVersionAsync(string version, CancellationToken cancellationToken = default)
    {
        bool result = await _dbContext.Patches.AnyAsync(p => p.Version == version, cancellationToken);
        return !result;
    }

    public Task CreatePatchAsync(CreatePatchDto patch, CancellationToken cancellationToken = default)
    {
        Patch patchEntity = _mapperService.Map<CreatePatchDto, Patch>(patch);
        _dbContext.Patches.Add(patchEntity);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
