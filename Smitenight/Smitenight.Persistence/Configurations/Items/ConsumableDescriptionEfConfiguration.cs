using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Items;

namespace Smitenight.Persistence.Configurations.Items
{
    public class ConsumableDescriptionEfConfiguration : IEntityTypeConfiguration<ConsumableDescription>
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
