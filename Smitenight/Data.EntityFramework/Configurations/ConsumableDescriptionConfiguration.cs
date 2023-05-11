using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class ConsumableDescriptionConfiguration : IEntityTypeConfiguration<ConsumableDescription>
    {
        public void Configure(EntityTypeBuilder<ConsumableDescription> builder)
        {
            builder.ToTable("ConsumableDescriptions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Consumable)
                .WithMany(x => x.ConsumableDescriptions)
                .HasForeignKey(x => x.ConsumableId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
