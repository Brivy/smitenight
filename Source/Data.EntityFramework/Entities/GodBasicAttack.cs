namespace Smitenight.Persistence.Data.EntityFramework.Entities;

public class GodBasicAttack
{
    public int Id { get; set; }
    public int GodId { get; set; }

    public string Description { get; set; } = null!;
    public string Value { get; set; } = null!;

    public God? God { get; set; }
}
