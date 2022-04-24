using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class CreateSmiteSessionMapper : Mapper<CreateSmiteSession, CreateSmiteSessionDto>
{
    public override CreateSmiteSessionDto Map(CreateSmiteSession input)
    {
        return new CreateSmiteSessionDto
        {
            RetMsg = input.RetMsg,
            SessionId = input.SessionId ?? string.Empty,
            Timestamp = input.Timestamp ?? string.Empty,
        };
    }
}
