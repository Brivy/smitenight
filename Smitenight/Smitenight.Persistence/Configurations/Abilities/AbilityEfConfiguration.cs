using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Abilities;

namespace Smitenight.Persistence.Configurations.Abilities
{
    public class AbilityEfConfiguration : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder.ToTable("Abilities");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.AbilityType).IsRequired();
            builder.Property(x => x.Cooldown).IsRequired();
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.Summary).IsRequired();
            builder.Property(x => x.Url).IsRequired();

            builder.HasOne(x => x.God)
                .WithMany(x => x.Abilities)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.AbilityRanks)
                .WithOne(x => x.Ability)
                .HasForeignKey(x => x.AbilityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.AbilityTags)
                .WithOne(x => x.Ability)
                .HasForeignKey(x => x.AbilityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
