using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class ItemDescriptionConfiguration : IEntityTypeConfiguration<ItemDescription>
    {
        public void Configure(EntityTypeBuilder<ItemDescription> builder)
        {
            builder.ToTable("ItemDescriptions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ItemId).IsRequired();

            builder.Property(x => x.Checksum).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Item)
                .WithMany(x => x.ItemDescriptions)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
