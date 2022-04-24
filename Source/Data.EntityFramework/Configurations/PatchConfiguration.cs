using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

public class PatchConfiguration : IEntityTypeConfiguration<Patch>
{
    public void Configure(EntityTypeBuilder<Patch> builder)
    {
        builder.ToTable("Patches");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Version).IsRequired();
        builder.Property(x => x.ReleaseDate).IsRequired();

        builder.HasMany(x => x.Abilities)
            .WithOne(x => x.Patch)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Actives)
            .WithOne(x => x.Patch)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Consumables)
            .WithOne(x => x.Patch)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Gods)
            .WithOne(x => x.Patch)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.GodSkins)
            .WithOne(x => x.Patch)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.Patch)
            .HasForeignKey(x => x.PatchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
