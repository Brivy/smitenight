using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class GodBanConfiguration : IEntityTypeConfiguration<GodBan>
{
    public void Configure(EntityTypeBuilder<GodBan> builder)
    {
        builder.ToTable("GodBans");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.GodId).IsRequired();
        builder.Property(x => x.MatchId).IsRequired();

        builder.Property(x => x.GodBanOrder).IsRequired();

        builder.HasOne(x => x.God)
            .WithMany(x => x.GodBans)
            .HasForeignKey(x => x.GodId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(x => x.Match)
            .WithMany(x => x.GodBans)
            .HasForeignKey(x => x.MatchId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
