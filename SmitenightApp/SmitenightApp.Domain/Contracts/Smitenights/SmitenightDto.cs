namespace SmitenightApp.Domain.Contracts.Smitenights
{
    public record class SmitenightDto
    {
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
