namespace Smitenight.Infrastructure.SmiteClient.Contracts.SystemResponses
{
    public class CreateSmiteSessionResponse : SmiteClientResponse
    {
        public string? ret_msg { get; init; }
        public string? session_id { get; init; }
        public string? timestamp { get; init; }
    }
}
