using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Persistence.Configurations.Gods
{
    public class BasicAttackDescriptionEfConfiguration : IEntityTypeConfiguration<BasicAttackDescription>
    {
        public void Configure(EntityTypeBuilder<BasicAttackDescription> builder)
        {
            builder.ToTable("BasicAttackDescriptions");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.God)
                .WithMany(x => x.BasicAttackDescriptions)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
