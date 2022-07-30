using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmitenightApp.Domain.Models.Abilities;

namespace SmitenightApp.Persistence.Configurations.Abilities
{
    public class AbilityRankEfConfiguration : IEntityTypeConfiguration<AbilityRank>
    {
        public void Configure(EntityTypeBuilder<AbilityRank> builder)
        {
            builder.ToTable("AbilityRanks");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Ability)
                .WithMany(x => x.AbilityRanks)
                .HasForeignKey(x => x.AbilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
