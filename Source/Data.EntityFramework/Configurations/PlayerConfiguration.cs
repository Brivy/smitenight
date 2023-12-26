using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.SmiteId).IsRequired(false);
        builder.Property(x => x.LastSynchronizedMatchId).IsRequired(false);
        builder.Property(x => x.SmitePortalUserId).IsRequired(false);

        builder.Property(x => x.HirezGamerTag).IsRequired(false);
        builder.Property(x => x.HirezPlayerName).IsRequired(false);
        builder.Property(x => x.Level).IsRequired();
        builder.Property(x => x.MasteryLevel).IsRequired();
        builder.Property(x => x.PlayerName).IsRequired(false);
        builder.Property(x => x.PortalType).IsRequired(false);
        builder.Property(x => x.PrivacyEnabled).IsRequired();

        builder.HasMany(x => x.MatchDetails)
            .WithOne(x => x.Player)
            .HasForeignKey(x => x.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Smitenights)
            .WithOne(x => x.Player)
            .HasForeignKey(x => x.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
