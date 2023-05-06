using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Models.Gods;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations.Gods
{
    public class GodBanEfConfiguration : IEntityTypeConfiguration<GodBan>
    {
        public void Configure(EntityTypeBuilder<GodBan> builder)
        {
            builder.ToTable("GodBans");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.GodBanOrder).IsRequired();

            builder.HasOne(x => x.God)
                .WithMany(x => x.GodBans)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Match)
                .WithMany(x => x.GodBans)
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
