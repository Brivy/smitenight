using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

public class AbilityRankConfigurationTypeConfiguration : IEntityTypeConfiguration<AbilityRank>
{
    public void Configure(EntityTypeBuilder<AbilityRank> builder)
    {
        builder.ToTable("AbilityRanks");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.AbilityId).IsRequired();

        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Value).IsRequired();

        builder.HasOne(x => x.Ability)
            .WithMany(x => x.AbilityRanks)
            .HasForeignKey(x => x.AbilityId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
