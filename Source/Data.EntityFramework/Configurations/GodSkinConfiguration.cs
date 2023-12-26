using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class GodSkinConfiguration : IEntityTypeConfiguration<GodSkin>
{
    public void Configure(EntityTypeBuilder<GodSkin> builder)
    {
        builder.ToTable("GodSkins");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.GodId).IsRequired();
        builder.Property(x => x.SmiteId).IsRequired();
        builder.Property(x => x.SecondarySmiteId).IsRequired();
        builder.Property(x => x.PatchId).IsRequired();

        builder.Property(x => x.Checksum).IsRequired();
        builder.Property(x => x.GodSkinUrl).IsRequired(false);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Obtainability).IsRequired();
        builder.Property(x => x.PriceFavor).IsRequired();
        builder.Property(x => x.PriceGems).IsRequired();
        builder.Property(x => x.Latest).IsRequired();

        builder.HasOne(x => x.Patch)
            .WithMany(x => x.GodSkins)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(x => x.God)
            .WithMany(x => x.GodSkins)
            .HasForeignKey(x => x.GodId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(x => x.MatchDetails)
            .WithOne(x => x.GodSkin)
            .HasForeignKey(x => x.GodSkinId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
