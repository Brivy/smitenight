using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Persistence.Configurations.Items
{
    public class ConsumableEfConfiguration : IEntityTypeConfiguration<Consumable>
    {
        public void Configure(EntityTypeBuilder<Consumable> builder)
        {
            builder.ToTable("Consumables");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.SecondaryDescription).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.ItemIconUrl).IsRequired();

            builder.HasMany(x => x.ConsumableDescriptions)
                .WithOne(x => x.Consumable)
                .HasForeignKey(x => x.ConsumableId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
