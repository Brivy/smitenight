using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Abilities;

namespace Smitenight.Persistence.Configurations.Abilities
{
    public class AbilityTagEfConfiguration : IEntityTypeConfiguration<AbilityTag>
    {
        public void Configure(EntityTypeBuilder<AbilityTag> builder)
        {
            builder.ToTable("AbilityTags");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Ability)
                .WithMany(x => x.AbilityTags)
                .HasForeignKey(x => x.AbilityId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
