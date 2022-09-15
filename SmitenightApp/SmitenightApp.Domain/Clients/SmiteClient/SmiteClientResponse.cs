using System.Net;

namespace SmitenightApp.Domain.Clients.SmiteClient
{
    public record class SmiteClientResponse(HttpStatusCode StatusCode, string? ReasonPhrase);

    public record class SmiteClientResponse<TResponse>(HttpStatusCode StatusCode, string? ReasonPhrase, TResponse? Response)
        : SmiteClientResponse(StatusCode, ReasonPhrase) where TResponse : class;

    public record class SmiteClientListResponse<TResponse>(HttpStatusCode StatusCode, string? ReasonPhrase, List<TResponse>? Response)
        : SmiteClientResponse(StatusCode, ReasonPhrase) where TResponse : class;
}
