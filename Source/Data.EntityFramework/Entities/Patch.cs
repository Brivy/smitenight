namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class Patch
{
    public int Id { get; set; }

    public string Version { get; set; } = null!;
    public DateTimeOffset ReleaseDate { get; set; }

    public ICollection<Ability> Abilities { get; set; }
    public ICollection<Active> Actives { get; set; }
    public ICollection<Consumable> Consumables { get; set; }
    public ICollection<God> Gods { get; set; }
    public ICollection<GodSkin> GodSkins { get; set; }
    public ICollection<Item> Items { get; set; }

    public Patch()
    {
        Abilities = new List<Ability>();
        Actives = new List<Active>();
        Consumables = new List<Consumable>();
        Gods = new List<God>();
        GodSkins = new List<GodSkin>();
        Items = new List<Item>();
    }
}
