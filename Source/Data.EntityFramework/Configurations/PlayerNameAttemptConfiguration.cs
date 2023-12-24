using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations;

public class PlayerNameAttemptConfiguration : IEntityTypeConfiguration<PlayerNameAttempt>
{
    public void Configure(EntityTypeBuilder<PlayerNameAttempt> builder)
    {
        builder.ToTable("PlayerNameAttempts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PlayerName).IsRequired();
        builder.Property(x => x.Attempts).IsRequired();
        builder.Property(x => x.FirstTimeUsed).IsRequired();
        builder.Property(x => x.LastTimeUsed).IsRequired();
        builder.Property(x => x.NextAttemptPossibleAt).IsRequired();
    }
}
