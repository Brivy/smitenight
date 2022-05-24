using Smitenight.Domain.Enums.SmiteClient;

namespace Smitenight.Domain.Clients.SmiteClient.Requests.GodRequests
{
    public record class GodRequest(
        int DeveloperId,
        string MethodName,
        string ResponseType,
        string Signature,
        string SessionId,
        string CurrentDate,
        LanguageCodeEnum LanguageCode) : SmiteClientRequest(DeveloperId, MethodName, ResponseType, Signature, SessionId, CurrentDate)
    {
        public override string GetUrlPath() =>
            ConstructUrlPath((int)LanguageCode);
    }
}
