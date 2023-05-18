using Smitenight.Application.Blazor.Business.Services.Checksums;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateBasicAttackDescriptionMapper : Mapper<BasicAttackItemDto, CreateBasicAttackDescriptionDto>
    {
        private readonly IChecksumService _checksumService;

        public CreateBasicAttackDescriptionMapper(IChecksumService checksumService)
        {
            _checksumService = checksumService;
        }

        public override CreateBasicAttackDescriptionDto Map(BasicAttackItemDto basicAttack)
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
