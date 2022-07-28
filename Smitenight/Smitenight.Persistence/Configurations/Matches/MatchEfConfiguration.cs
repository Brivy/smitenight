using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Matches;

namespace Smitenight.Persistence.Configurations.Matches
{
    public class MatchEfConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Matches");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.GameMap).IsRequired();
            builder.Property(x => x.GameModeQueue).IsRequired();
            builder.Property(x => x.MatchDuration).IsRequired();
            builder.Property(x => x.TeamOneScore).IsRequired();
            builder.Property(x => x.TeamTwoScore).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Region).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();

            builder.HasMany(x => x.GodBans)
                .WithOne(x => x.Match)
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.MatchDetails)
                .WithOne(x => x.Match)
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
