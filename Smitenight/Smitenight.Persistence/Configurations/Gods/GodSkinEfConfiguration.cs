using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Persistence.Configurations.Gods
{
    public class GodSkinEfConfiguration : IEntityTypeConfiguration<GodSkin>
    {
        public void Configure(EntityTypeBuilder<GodSkin> builder)
        {
            builder.ToTable("GodSkins");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.GodSkinUrl).IsRequired(false);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Obtainability).IsRequired();
            builder.Property(x => x.PriceFavor).IsRequired();
            builder.Property(x => x.PriceGems).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.SecondarySmiteId).IsRequired();

            builder.HasOne(x => x.God)
                .WithMany(x => x.GodSkins)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
