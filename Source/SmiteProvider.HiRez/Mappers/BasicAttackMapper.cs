using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;
using Smitenight.Utilities.Mapper.Common.Services;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class BasicAttackMapper : Mapper<BasicAttack, BasicAttackDto>
    {
        private readonly IMapperService _mapperService;

        public BasicAttackMapper(IMapperService mapperService)
        {
            _mapperService = mapperService;
        }

        public override BasicAttackDto Map(BasicAttack input)
        {
            var basicAttackDescription = input.ItemDescription;
            return new BasicAttackDto
            {
                Cooldown = basicAttackDescription.Cooldown ?? string.Empty,
                Cost = basicAttackDescription.Cost ?? string.Empty,
                Description = basicAttackDescription.Description ?? string.Empty,
                BasicAttackItems = _mapperService.Map<CommonItem[], CommonItemDto[]>(basicAttackDescription.BasicAttackItems),
                BasicAttackRanks = _mapperService.Map<CommonItem[], CommonItemDto[]>(basicAttackDescription.BasicAttackRanks)
            };
        }
    }
}
