﻿namespace Smitenight.Persistence.Data.EntityFramework.Entities;

internal class Consumable
{
    public int Id { get; set; }
    public int SmiteId { get; set; }
    public int PatchId { get; set; }

    public string Checksum { get; set; } = null!;
    public bool Enabled { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int Price { get; set; }
    public string? SecondaryDescription { get; set; }
    public string? ShortDescription { get; set; }
    public string ItemIconUrl { get; set; } = null!;
    public bool Latest { get; set; }

    public Patch? Patch { get; set; }
}
