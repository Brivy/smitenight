using System.Net;

namespace Smitenight.Infrastructure.SmiteClient.Contracts
{
    public class SmiteClientResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? ReasonPhrase { get; set; }
    }
}
