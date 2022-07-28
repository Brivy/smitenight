using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Items;

namespace Smitenight.Persistence.Configurations.Items
{
    public class ActivePurchaseEfConfiguration : IEntityTypeConfiguration<ActivePurchase>
    {
        public void Configure(EntityTypeBuilder<ActivePurchase> builder)
        {
            builder.ToTable("ActivePurchases");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActivePurchaseOrder).IsRequired();

            builder.HasOne(x => x.Active)
                .WithMany(x => x.ActivePurchases)
                .HasForeignKey(x => x.ActiveId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.MatchDetail)
                .WithMany(x => x.ActivePurchases)
                .HasForeignKey(x => x.ActiveId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
