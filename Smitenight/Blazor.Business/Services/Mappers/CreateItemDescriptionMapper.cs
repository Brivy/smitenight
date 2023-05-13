using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient;
using Smitenight.Utilities.Mapper.Common.Models;

namespace Smitenight.Application.Blazor.Business.Services.Mappers
{
    public class CreateItemDescriptionMapper : Mapper<MenuItem, CreateItemDescriptionDto>
    {
        public override CreateItemDescriptionDto Map(MenuItem itemDescription)
        {
            return new CreateItemDescriptionDto
            {
                Description = itemDescription.Description!, // An item always has a description otherwise what is the point of the item?
                Value = itemDescription.Value! // An item always has a description otherwise what is the point of the item?
            };
        }
    }
}
