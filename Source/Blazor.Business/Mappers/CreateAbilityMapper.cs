using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Enums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Mappers
{
    public class CreateAbilityMapper : Mapper<AbilityDetailsDto, CreateAbilityDto>
    {
        private readonly IChecksumService _checksumService;

        public CreateAbilityMapper(IChecksumService checksumService)
        {
            _checksumService = checksumService;
        }

        public override CreateAbilityDto Map(AbilityDetailsDto ability)
        {
            var checksum = _checksumService.CalculateChecksum(ability);
            return new CreateAbilityDto
            {
                Checksum = checksum,
                AbilityType = AbilityType.Primary,
                Cooldown = !string.IsNullOrWhiteSpace(ability.Cooldown) ? ability.Cooldown : null,
                Cost = !string.IsNullOrWhiteSpace(ability.Cost) ? ability.Cost : null,
                Description = ability.Description,
                SmiteId = ability.Id,
                Summary = ability.Summary,
                Url = ability.Url
            };
        }
    }
}
