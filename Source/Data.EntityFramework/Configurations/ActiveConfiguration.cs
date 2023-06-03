using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class ActiveConfiguration : IEntityTypeConfiguration<Active>
    {
        public void Configure(EntityTypeBuilder<Active> builder)
        {
            builder.ToTable("Actives");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.ChildActiveId).IsRequired(false);
            builder.Property(x => x.RootActiveId).IsRequired(false);
            builder.Property(x => x.PatchId).IsRequired();

            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.SecondaryDescription).IsRequired(false);
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired(false);
            builder.Property(x => x.ItemIconUrl).IsRequired();
            builder.Property(x => x.ItemTier).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Latest).IsRequired();

            builder.HasOne(x => x.Patch)
                .WithMany(x => x.Actives)
                .HasForeignKey(x => x.PatchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.ChildActive)
                .WithMany()
                .HasForeignKey(x => x.ChildActiveId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.RootActive)
                .WithMany()
                .HasForeignKey(x => x.RootActiveId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ActivePurchases)
                .WithOne(x => x.Active)
                .HasForeignKey(x => x.ActiveId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
