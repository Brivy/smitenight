using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

internal class ActivePurchaseConfiguration : IEntityTypeConfiguration<ActivePurchase>
{
    public void Configure(EntityTypeBuilder<ActivePurchase> builder)
    {
        builder.ToTable("ActivePurchases");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.ActiveId).IsRequired();
        builder.Property(x => x.MatchDetailId).IsRequired();

        builder.Property(x => x.ActivePurchaseOrder).IsRequired();

        builder.HasOne(x => x.Active)
            .WithMany(x => x.ActivePurchases)
            .HasForeignKey(x => x.ActiveId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(x => x.MatchDetail)
            .WithMany(x => x.ActivePurchases)
            .HasForeignKey(x => x.ActiveId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
