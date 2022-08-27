using Microsoft.EntityFrameworkCore;
using SmitenightApp.Domain.Models.Players;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmitenightApp.Persistence.Configurations.Players
{
    public class PlayerNameAttemptEfConfiguration : IEntityTypeConfiguration<PlayerNameAttempt>
    {
        public void Configure(EntityTypeBuilder<PlayerNameAttempt> builder)
        {
            builder.ToTable("PlayerNameAttempts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.PlayerName).IsRequired();
            builder.Property(x => x.Attempts).IsRequired();
            builder.Property(x => x.FirstTimeUsed).IsRequired();
            builder.Property(x => x.NextAttemptPossibleAt).IsRequired();
        }
    }
}
