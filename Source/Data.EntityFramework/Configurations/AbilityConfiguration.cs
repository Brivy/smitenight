using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class AbilityConfiguration : IEntityTypeConfiguration<Ability>
    {
        public void Configure(EntityTypeBuilder<Ability> builder)
        {
            builder.ToTable("Abilities");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.GodId).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();

            builder.Property(x => x.Checksum).IsRequired();
            builder.Property(x => x.Cooldown).IsRequired(false);
            builder.Property(x => x.Cost).IsRequired(false);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Summary).IsRequired();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.AbilityType).IsRequired();


            //builder.HasOne(x => x.God)
            //    .WithMany(x => x.Abilities)
            //    .HasForeignKey(x => x.GodId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .IsRequired();

            //builder.HasMany(x => x.AbilityRanks)
            //    .WithOne(x => x.Ability)
            //    .HasForeignKey(x => x.AbilityId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(x => x.AbilityTags)
            //    .WithOne(x => x.Ability)
            //    .HasForeignKey(x => x.AbilityId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
