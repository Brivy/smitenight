using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class AbilityTagConfiguration : IEntityTypeConfiguration<AbilityTag>
{
    public void Configure(EntityTypeBuilder<AbilityTag> builder)
    {
        builder.ToTable("AbilityTags");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.AbilityId).IsRequired();

        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Value).IsRequired();

        builder.HasOne(x => x.Ability)
            .WithMany(x => x.AbilityTags)
            .HasForeignKey(x => x.AbilityId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
