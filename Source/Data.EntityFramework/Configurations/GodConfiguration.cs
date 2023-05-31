using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations
{
    public class GodConfiguration : IEntityTypeConfiguration<God>
    {
        public void Configure(EntityTypeBuilder<God> builder)
        {
            builder.ToTable("Gods");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.PatchId).IsRequired();

            builder.Property(x => x.Checksum).IsRequired();
            builder.Property(x => x.AttackSpeed).IsRequired();
            builder.Property(x => x.AttackSpeedPerLevel).IsRequired();
            builder.Property(x => x.AutoBanned).IsRequired();
            builder.Property(x => x.GodCardUrl).IsRequired();
            builder.Property(x => x.GodIconUrl).IsRequired();
            builder.Property(x => x.Hp5PerLevel).IsRequired();
            builder.Property(x => x.Health).IsRequired();
            builder.Property(x => x.HealthPerFive).IsRequired();
            builder.Property(x => x.HealthPerLevel).IsRequired();
            builder.Property(x => x.LatestGod).IsRequired();
            builder.Property(x => x.Lore).IsRequired();
            builder.Property(x => x.Mp5PerLevel).IsRequired();
            builder.Property(x => x.MagicProtection).IsRequired();
            builder.Property(x => x.MagicProtectionPerLevel).IsRequired();
            builder.Property(x => x.MagicalPower).IsRequired();
            builder.Property(x => x.MagicalPowerPerLevel).IsRequired();
            builder.Property(x => x.Mana).IsRequired();
            builder.Property(x => x.ManaPerFive).IsRequired();
            builder.Property(x => x.ManaPerLevel).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.OnFreeRotation).IsRequired();
            builder.Property(x => x.Pantheon).IsRequired();
            builder.Property(x => x.PhysicalPower).IsRequired();
            builder.Property(x => x.PhysicalPowerPerLevel).IsRequired();
            builder.Property(x => x.PhysicalProtection).IsRequired();
            builder.Property(x => x.PhysicalProtectionPerLevel).IsRequired();
            builder.Property(x => x.Pros).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Speed).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasOne(x => x.Patch)
                .WithMany(x => x.Gods)
                .HasForeignKey(x => x.PatchId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(x => x.Abilities)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GodBasicAttacks)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GodBans)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GodSkins)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(x => x.MatchDetails)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
