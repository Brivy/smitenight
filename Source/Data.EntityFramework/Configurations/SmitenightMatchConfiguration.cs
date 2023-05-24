using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class SmitenightMatchConfiguration : IEntityTypeConfiguration<SmitenightMatch>
    {
        public void Configure(EntityTypeBuilder<SmitenightMatch> builder)
        {
            builder.ToTable("SmitenightMatches");

            builder.HasKey(x => x.Id);
            builder.HasKey(x => x.MatchId);
            builder.HasKey(x => x.SmitenightId);

            //builder.HasOne(x => x.Match)
            //    .WithMany(x => x.SmitenightMatches)
            //    .HasForeignKey(x => x.MatchId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();

            //builder.HasOne(x => x.Smitenight)
            //    .WithMany(x => x.SmitenightMatches)
            //    .HasForeignKey(x => x.SmitenightId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
