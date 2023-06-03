using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Contracts.Contracts;
using Smitenight.Utilities.Mapper.Models;
using AbilityType = Smitenight.Persistence.Data.Contracts.Enums.AbilityType;

namespace Smitenight.Application.Blazor.Business.Mappers
{
    public class CreateAbilityMapper : Mapper<AbilityDetailsDto, CreateAbilityDto>
    {
        private readonly IChecksumService _checksumService;
        private readonly IMapper<CommonItemDto, CreateAbilityRankDto> _abilityRankMapper;
        private readonly IMapper<CommonItemDto, CreateAbilityTagDto> _abilityTagMapper;

        public CreateAbilityMapper(
            IChecksumService checksumService,
            IMapper<CommonItemDto, CreateAbilityRankDto> abilityRankMapper,
            IMapper<CommonItemDto, CreateAbilityTagDto> abilityTagMapper)
        {
            _checksumService = checksumService;
            _abilityRankMapper = abilityRankMapper;
            _abilityTagMapper = abilityTagMapper;
        }

        public override CreateAbilityDto Map(AbilityDetailsDto ability)
        {
            var checksum = _checksumService.CalculateChecksum(ability);
            return new CreateAbilityDto
            {
                Checksum = checksum,
                AbilityType = (AbilityType)ability.AbilityType,
                Cooldown = !string.IsNullOrWhiteSpace(ability.Cooldown) ? ability.Cooldown : null,
                Cost = !string.IsNullOrWhiteSpace(ability.Cost) ? ability.Cost : null,
                Description = ability.Description,
                SmiteId = ability.Id,
                Summary = ability.Summary,
                Url = ability.Url,
                AbilityRanks = ability.AbilityRanks.Select(_abilityRankMapper.Map).ToArray(),
                AbilityTags = ability.AbilityRanks.Select(_abilityTagMapper.Map).ToArray()
            };
        }
    }
}
