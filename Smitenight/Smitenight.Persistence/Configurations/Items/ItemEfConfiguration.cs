using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Items;

namespace Smitenight.Persistence.Configurations.Items
{
    public class ItemEfConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActiveFlag).IsRequired();
            builder.Property(x => x.ChildItemId).IsRequired(false);
            builder.Property(x => x.DeviceName).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Glyph).IsRequired();
            builder.Property(x => x.RestrictedRoles).IsRequired();
            builder.Property(x => x.RootItemId).IsRequired(false);
            builder.Property(x => x.SecondaryDescription).IsRequired(false);
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.ItemIconUrl).IsRequired();

            builder.HasOne(x => x.ChildItem)
                .WithMany()
                .HasForeignKey(x => x.ChildItemId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RootItem)
                .WithMany()
                .HasForeignKey(x => x.RootItemId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ItemDescriptions)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
