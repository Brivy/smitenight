namespace SmitenightApp.Domain.Contracts.Abilities
{
    public class AbilityRankDto
    {
        public string Description { get; set; } = null!;
        public string Value { get; set; } = null!;

        public AbilityDto? Ability { get; set; }
    }
}
