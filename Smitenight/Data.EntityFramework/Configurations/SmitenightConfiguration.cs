using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class SmitenightConfiguration : IEntityTypeConfiguration<Entities.Smitenight>
    {
        public void Configure(EntityTypeBuilder<Entities.Smitenight> builder)
        {
            builder.ToTable("Smitenights");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired(false);
            builder.Property(x => x.PinCode).IsRequired(false);

            builder.HasOne(x => x.Player)
                .WithMany(x => x.Smitenights)
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.SmitenightMatches)
                .WithOne(x => x.Smitenight)
                .HasForeignKey(x => x.SmitenightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
