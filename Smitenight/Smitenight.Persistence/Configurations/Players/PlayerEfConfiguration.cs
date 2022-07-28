using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Players;

namespace Smitenight.Persistence.Configurations.Players
{
    public class PlayerEfConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.HirezPlayerName).IsRequired();
            builder.Property(x => x.Level).IsRequired();
            builder.Property(x => x.MasteryLevel).IsRequired();
            builder.Property(x => x.PlayerName).IsRequired();
            builder.Property(x => x.PortalType).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.SmitePortalUserId).IsRequired(false);

            builder.HasMany(x => x.MatchDetails)
                .WithOne(x => x.Player)
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
