using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmitenightApp.Domain.Models.Smitenights;

namespace SmitenightApp.Persistence.Configurations.Smitenights
{
    public class SmitenightEfConfiguration : IEntityTypeConfiguration<Smitenight>
    {
        public void Configure(EntityTypeBuilder<Smitenight> builder)
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
