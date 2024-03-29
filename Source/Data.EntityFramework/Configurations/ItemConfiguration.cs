﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.SmiteId).IsRequired();
        builder.Property(x => x.RootItemId).IsRequired(false);
        builder.Property(x => x.ChildItemId).IsRequired(false);
        builder.Property(x => x.PatchId).IsRequired();

        builder.Property(x => x.Checksum).IsRequired();
        builder.Property(x => x.Enabled).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.Glyph).IsRequired();
        builder.Property(x => x.ItemTier).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.RestrictedRoles).IsRequired();
        builder.Property(x => x.SecondaryDescription).IsRequired(false);
        builder.Property(x => x.ShortDescription).IsRequired(false);
        builder.Property(x => x.StartingItem).IsRequired();
        builder.Property(x => x.ItemIconUrl).IsRequired();
        builder.Property(x => x.Latest).IsRequired();

        builder.HasOne(x => x.Patch)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(x => x.ChildItem)
            .WithMany()
            .HasForeignKey(x => x.ChildItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RootItem)
            .WithMany()
            .HasForeignKey(x => x.RootItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ItemDescriptions)
            .WithOne(x => x.Item)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ItemPurchases)
            .WithOne(x => x.Item)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
