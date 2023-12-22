using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainPatchesService : IMaintainPatchesService
    {
        private readonly IMaintainPatchesRepository _maintainPatchesRepository;
        private readonly TimeProvider _timeProvider;


        public MaintainPatchesService(IMaintainPatchesRepository maintainPatchesRepository, TimeProvider timeProvider)
        {
            _maintainPatchesRepository = maintainPatchesRepository;
            _timeProvider = timeProvider;
        }

        public async Task MaintainPatchAsync(string version, CancellationToken cancellationToken = default)
        {
            if (await _maintainPatchesRepository.IsNewVersionAsync(version, cancellationToken))
            {
                await CreatePatchAsync(version, cancellationToken);
            }
        }

        private Task CreatePatchAsync(string version, CancellationToken cancellationToken = default)
        {
            var patchDto = new CreatePatchDto
            {
                Version = version,
                ReleaseDate = _timeProvider.GetUtcNow()
            };

            return _maintainPatchesRepository.CreatePatchAsync(patchDto, cancellationToken);
        }
    }
}
