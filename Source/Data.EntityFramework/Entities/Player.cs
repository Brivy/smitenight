using Smitenight.Persistence.Data.Contracts.Enums;

namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class Player
{
    public int Id { get; set; }
    public int? SmiteId { get; set; }
    public int? LastSynchronizedMatchId { get; set; }
    public long? SmitePortalUserId { get; set; }

    public string? HirezGamerTag { get; set; }
    public string? HirezPlayerName { get; set; }
    public int Level { get; set; }
    public int MasteryLevel { get; set; }
    public string? PlayerName { get; set; }
    public PortalType? PortalType { get; set; }
    public bool PrivacyEnabled { get; set; }

    public ICollection<MatchDetail> MatchDetails { get; set; }
    public ICollection<Smitenight> Smitenights { get; set; }

    public Player()
    {
        MatchDetails = new List<MatchDetail>();
        Smitenights = new List<Smitenight>();
    }
}
