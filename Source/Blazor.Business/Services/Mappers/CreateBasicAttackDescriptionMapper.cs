using Smitenight.Application.Blazor.Business.Contracts.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateBasicAttackDescriptionMapper : Mapper<CommonItemDto, CreateBasicAttackDescriptionDto>
    {
        private readonly IChecksumService _checksumService;

        public CreateBasicAttackDescriptionMapper(IChecksumService checksumService)
        {
            _checksumService = checksumService;
        }

        public override CreateBasicAttackDescriptionDto Map(CommonItemDto basicAttack)
        {
            var checksum = _checksumService.CalculateChecksum(basicAttack);
            return new CreateBasicAttackDescriptionDto
            {
                Checksum = checksum,
                Description = basicAttack.Description,
                Value = basicAttack.Value
            };
        }
    }
}
