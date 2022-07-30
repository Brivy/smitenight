using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmitenightApp.Domain.Models.Items;

namespace SmitenightApp.Persistence.Configurations.Items
{
    public class ItemDescriptionEfConfiguration : IEntityTypeConfiguration<ItemDescription>
    {
        public void Configure(EntityTypeBuilder<ItemDescription> builder)
        {
            builder.ToTable("ItemDescriptions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Item)
                .WithMany(x => x.ItemDescriptions)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
