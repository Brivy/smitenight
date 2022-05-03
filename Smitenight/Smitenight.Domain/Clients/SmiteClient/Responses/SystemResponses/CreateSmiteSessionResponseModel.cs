using System.Net;

namespace Smitenight.Domain.Clients.SmiteClient.Responses.SystemResponses
{
    public record class CreateSmiteSessionResponseModel(HttpStatusCode StatusCode, string ReasonPhrase, string RetMsg, string SessionId, string Timestamp) 
        : SmiteClientResponseModel(StatusCode, ReasonPhrase);
}
