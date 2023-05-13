using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Smitenight.Application.Blazor.Business.Contracts.Enums;
using Smitenight.Application.Blazor.Business.Contracts.Services.Gods;
using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Gods;
using Smitenight.Persistence.Data.EntityFramework;

namespace Smitenight.Application.Blazor.Business.Services.Gods
{
    public class GodService : IGodService
    {
        private readonly SmitenightDbContext _dbContext;
        private readonly IMapper _mapper;

        public GodService(SmitenightDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default)
        {
            const int totalSkinsForShow = 20;
            var random = new Random();
            var randomIds = new List<int>();

            var totalSkins = await _dbContext.GodSkins.AsNoTracking().CountAsync(cancellationToken);
            for (var i = 0; i < totalSkinsForShow; i++)
            {
                randomIds.Add(random.Next(1, totalSkins));
            }

            var result = await _dbContext.GodSkins.AsNoTracking().Where(x => randomIds.Contains(x.Id)).ToListAsync(cancellationToken);
            return new ServerResponseDto<List<GodSkinDto>>(StatusCodeEnum.Success, _mapper.Map<List<GodSkinDto>>(result));
        }
    }
}
