namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient
{
    public record class HirezServerStatusDto(
        string EntryDatetime,
        string Environment,
        bool LimitedAccess,
        string Platform,
        object RetMsg,
        string Status,
        string Version);
}