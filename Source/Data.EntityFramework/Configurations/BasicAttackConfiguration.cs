using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class BasicAttackConfiguration : IEntityTypeConfiguration<BasicAttack>
    {
        public void Configure(EntityTypeBuilder<BasicAttack> builder)
        {
            builder.ToTable("BasicAttacks");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.GodId).IsRequired();

            builder.Property(x => x.Checksum).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.God)
                .WithMany(x => x.BasicAttackDescriptions)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
