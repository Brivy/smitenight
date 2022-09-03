using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Gods;
using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Gods;
using SmitenightApp.Domain.Enums.StatusCodes;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Gods
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
