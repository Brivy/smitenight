using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class ItemPurchaseConfiguration : IEntityTypeConfiguration<ItemPurchase>
{
    public void Configure(EntityTypeBuilder<ItemPurchase> builder)
    {
        builder.ToTable("ItemPurchases");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ItemId).IsRequired();
        builder.Property(x => x.MatchDetailId).IsRequired();

        builder.Property(x => x.PurchaseOrder).IsRequired();

        builder.HasOne(x => x.Item)
            .WithMany(x => x.ItemPurchases)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(x => x.MatchDetail)
            .WithMany(x => x.ItemPurchases)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
