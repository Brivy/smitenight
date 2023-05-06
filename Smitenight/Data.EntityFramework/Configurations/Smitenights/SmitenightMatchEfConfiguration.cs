using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Models.Smitenights;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations.Smitenights
{
    public class SmitenightMatchEfConfiguration : IEntityTypeConfiguration<SmitenightMatch>
    {
        public void Configure(EntityTypeBuilder<SmitenightMatch> builder)
        {
            builder.ToTable("SmitenightMatches");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Match)
                .WithMany(x => x.SmitenightMatches)
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Smitenight)
                .WithMany(x => x.SmitenightMatches)
                .HasForeignKey(x => x.SmitenightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
