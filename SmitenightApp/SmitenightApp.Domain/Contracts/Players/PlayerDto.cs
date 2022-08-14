using SmitenightApp.Domain.Contracts.Matches;
using SmitenightApp.Domain.Contracts.Smitenights;
using SmitenightApp.Domain.Enums.SmiteClient;

namespace SmitenightApp.Domain.Contracts.Players
{
    public class PlayerDto
    {
        public string? HirezGamerTag { get; set; }
        public string? HirezPlayerName { get; set; }
        public int Level { get; set; }
        public int MasteryLevel { get; set; }
        public string? PlayerName { get; set; }
        public PortalTypeEnum? PortalType { get; set; }
        public bool PrivacyEnabled { get; set; }

        public List<MatchDetailDto> MatchDetails { get; set; }
        public List<SmitenightDto> Smitenights { get; set; }

        public PlayerDto()
        {
            MatchDetails = new List<MatchDetailDto>();
            Smitenights = new List<SmitenightDto>();
        }
    }
}
