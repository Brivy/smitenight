namespace Smitenight.Domain.Clients.SmiteClient.Responses.RetrievePlayerResponses
{
    public record class PlayerIdResponseDto(
        int PlayerId,
        string Portal,
        string PortalId,
        string PrivacyFlag,
        object RetMsg
    );
}
