﻿using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainPatchesService : IMaintainPatchesService
    {
        private readonly IMaintainPatchesRepository _maintainPatchesRepository;

        public MaintainPatchesService(IMaintainPatchesRepository maintainPatchesRepository)
        {
            _maintainPatchesRepository = maintainPatchesRepository;
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
                ReleaseDate = DateTime.UtcNow
            };

            return _maintainPatchesRepository.CreatePatchAsync(patchDto, cancellationToken);
        }
    }
}