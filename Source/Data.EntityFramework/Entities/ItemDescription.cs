﻿namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class ItemDescription
{
    public int Id { get; set; }
    public int ItemId { get; set; }

    public string Description { get; set; } = null!;
    public string Value { get; set; } = null!;

    public Item? Item { get; set; }
}
