using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Models.Abilities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations.Abilities
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
