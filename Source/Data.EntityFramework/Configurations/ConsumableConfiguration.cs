using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class ConsumableConfiguration : IEntityTypeConfiguration<Consumable>
    {
        public void Configure(EntityTypeBuilder<Consumable> builder)
        {
            builder.ToTable("Consumables");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.PatchId).IsRequired();

            builder.Property(x => x.Checksum).IsRequired();
            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.SecondaryDescription).IsRequired(false);
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.ShortDescription).IsRequired(false);
            builder.Property(x => x.ItemIconUrl).IsRequired();
            builder.Property(x => x.Latest).IsRequired();

            builder.HasOne(x => x.Patch)
                .WithMany(x => x.Consumables)
                .HasForeignKey(x => x.PatchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
