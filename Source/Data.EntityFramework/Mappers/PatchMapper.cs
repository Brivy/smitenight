using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.EntityFramework.Entities;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Persistence.Data.EntityFramework.Mappers;

public class PatchMapper : Mapper<CreatePatchDto, Patch>
{
    public override Patch Map(CreatePatchDto input)
    {
        return new Patch
        {
            Version = input.Version,
            ReleaseDate = input.ReleaseDate
        };
    }
}
