using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using Smitenight.Providers.SmiteProvider.HiRez.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Contracts;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers
{
    public class BasicAttackMapper : Mapper<BasicAttack, BasicAttackDto>
    {
        private readonly IMapper<CommonItem, CommonItemDto> _commonItemMapper;

        public BasicAttackMapper(IMapper<CommonItem, CommonItemDto> commonItemMapper)
        {
            _commonItemMapper = commonItemMapper;
        }

        public override BasicAttackDto Map(BasicAttack input)
        {
            var basicAttackDescription = input.ItemDescription;
            return new BasicAttackDto
            {
                Cooldown = basicAttackDescription.Cooldown ?? string.Empty,
                Cost = basicAttackDescription.Cost ?? string.Empty,
                Description = basicAttackDescription.Description ?? string.Empty,
                BasicAttackItems = basicAttackDescription.BasicAttackItems.Select(_commonItemMapper.Map).ToArray(),
                BasicAttackRanks = basicAttackDescription.BasicAttackRanks.Select(_commonItemMapper.Map).ToArray()
            };
        }
    }
}
