using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Items;

namespace Smitenight.Persistence.Configurations.Items
{
    public class ActiveEfConfiguration : IEntityTypeConfiguration<Active>
    {
        public void Configure(EntityTypeBuilder<Active> builder)
        {
            builder.ToTable("Actives");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ChildActiveId).IsRequired(false);
            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.RootActiveId).IsRequired(false);
            builder.Property(x => x.SecondaryDescription).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired();
            builder.Property(x => x.ItemIconUrl).IsRequired();
            builder.Property(x => x.ItemTier).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.ChildActive)
                .WithMany()
                .HasForeignKey(x => x.ChildActiveId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RootActive)
                .WithMany()
                .HasForeignKey(x => x.RootActiveId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ActivePurchases)
                .WithOne(x => x.Active)
                .HasForeignKey(x => x.ActiveId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
