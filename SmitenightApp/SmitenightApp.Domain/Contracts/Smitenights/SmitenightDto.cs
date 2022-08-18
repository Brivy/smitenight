using SmitenightApp.Domain.Contracts.Players;

namespace SmitenightApp.Domain.Contracts.Smitenights
{
    public class SmitenightDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? PinCode { get; set; }

        public PlayerDto? Player { get; set; }
        public List<SmitenightMatchDto> SmitenightMatches { get; set; }

        public SmitenightDto()
        {
            SmitenightMatches = new List<SmitenightMatchDto>();
        }
    }
}
