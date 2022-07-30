namespace SmitenightApp.Domain.Clients.SmiteClient.Responses.TeamResponses
{
    public record class SearchTeamsResponse
    (
        string? Founder,
        string? Name,
        int Players,
        string? Tag,
        int TeamId,
        string? RetMsg
    );
}
