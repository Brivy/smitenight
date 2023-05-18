namespace Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient
{
    public record class HirezServerStatusDto
    {
        public string EntryDatetime { get; init; } = null!;
        public string Environment { get; init; } = null!;
        public bool LimitedAccess { get; init; }
        public string Platform { get; init; } = null!;
        public string? RetMsg { get; init; }
        public string Status { get; init; } = null!;
        public string Version { get; init; } = null!;
    }
}