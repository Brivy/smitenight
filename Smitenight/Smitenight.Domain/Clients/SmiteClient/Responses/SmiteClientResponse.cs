using System.Net;

namespace Smitenight.Domain.Clients.SmiteClient.Responses
{
    public record class SmiteClientResponseModel(HttpStatusCode StatusCode, string? ReasonPhrase);
}
