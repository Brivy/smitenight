using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class GodBasicAttackConfiguration : IEntityTypeConfiguration<GodBasicAttack>
{
    public void Configure(EntityTypeBuilder<GodBasicAttack> builder)
    {
        builder.ToTable("GodBasicAttacks");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.GodId).IsRequired();

        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Value).IsRequired();

        builder.HasOne(x => x.God)
            .WithMany(x => x.GodBasicAttacks)
            .HasForeignKey(x => x.GodId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
