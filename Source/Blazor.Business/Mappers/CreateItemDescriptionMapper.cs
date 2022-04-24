using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.Contracts.Models.Common;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Application.Core.Business.Mappers;

public class CreateItemDescriptionMapper : Mapper<CommonItemDto, CreateItemDescriptionDto>
{
    public override CreateItemDescriptionDto Map(CommonItemDto itemDescription)
    {
        return new CreateItemDescriptionDto
        {
            Description = itemDescription.Description!, // An item always has a description otherwise what is the point of the item?
            Value = itemDescription.Value! // An item always has a description otherwise what is the point of the item?
        };
    }
}
