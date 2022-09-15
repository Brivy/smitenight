namespace SmitenightApp.Domain.Clients.SystemClient
{
    public record class CreateSmiteSessionResponse(
        string RetMsg,
        string SessionId, 
        string Timestamp);
}
