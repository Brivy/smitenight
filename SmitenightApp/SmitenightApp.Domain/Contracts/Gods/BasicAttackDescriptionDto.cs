namespace SmitenightApp.Domain.Contracts.Gods
{
    public class BasicAttackDescriptionDto
    {
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        public GodDto? God { get; set; }
    }
}
