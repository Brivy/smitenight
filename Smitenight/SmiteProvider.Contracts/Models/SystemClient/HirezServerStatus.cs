namespace Smitenight.Domain.Models.Clients.SystemClient
{
    public record class HirezServerStatus(
        string EntryDatetime,
        string Environment,
        bool LimitedAccess,
        string Platform,
        object RetMsg,
        string Status,
        string Version);
}