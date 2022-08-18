using SmitenightApp.Domain.Constants.SmiteClient;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Clients.SmiteClient.Requests.ItemRequests
{
    public record class ItemsRequest(
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(MethodNameConstants.ItemsMethod)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)LanguageCode);
    }
}
