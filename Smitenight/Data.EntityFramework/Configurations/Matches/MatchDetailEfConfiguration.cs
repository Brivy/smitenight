using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Persistence.Data.EntityFramework.Configurations.Matches
{
    public class MatchDetailEfConfiguration : IEntityTypeConfiguration<MatchDetail>
    {
        public void Configure(EntityTypeBuilder<MatchDetail> builder)
        {
            builder.ToTable("MatchDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.DamageDone).IsRequired();
            builder.Property(x => x.DamageDoneInHand).IsRequired();
            builder.Property(x => x.DamageDoneMagical).IsRequired();
            builder.Property(x => x.DamageDonePhysical).IsRequired();
            builder.Property(x => x.DamageDoneToBots).IsRequired();
            builder.Property(x => x.DamageDoneToStructures).IsRequired();
            builder.Property(x => x.DamageTaken).IsRequired();
            builder.Property(x => x.DamageTakenMagical).IsRequired();
            builder.Property(x => x.DamageTakenPhysical).IsRequired();
            builder.Property(x => x.DamageMitigated).IsRequired();
            builder.Property(x => x.Assists).IsRequired();
            builder.Property(x => x.Deaths).IsRequired();
            builder.Property(x => x.FirstBlood).IsRequired();
            builder.Property(x => x.SingleKills).IsRequired();
            builder.Property(x => x.DoubleKills).IsRequired();
            builder.Property(x => x.TripleKills).IsRequired();
            builder.Property(x => x.QuadraKills).IsRequired();
            builder.Property(x => x.PentaKills).IsRequired();
            builder.Property(x => x.HighestMultiKill).IsRequired();
            builder.Property(x => x.KillingSpree).IsRequired();
            builder.Property(x => x.BotKills).IsRequired();
            builder.Property(x => x.PlayerKills).IsRequired();
            builder.Property(x => x.FireGiantKills).IsRequired();
            builder.Property(x => x.GoldFuryKills).IsRequired();
            builder.Property(x => x.PhoenixKills).IsRequired();
            builder.Property(x => x.SiegeJuggernautKills).IsRequired();
            builder.Property(x => x.TowerKills).IsRequired();
            builder.Property(x => x.WildJuggernautKills).IsRequired();
            builder.Property(x => x.ObjectiveAssists).IsRequired();
            builder.Property(x => x.DistanceTraveled).IsRequired();
            builder.Property(x => x.GodRole).IsRequired();
            builder.Property(x => x.GoldEarned).IsRequired();
            builder.Property(x => x.GoldEarnedPerMinute).IsRequired();
            builder.Property(x => x.HealingDone).IsRequired();
            builder.Property(x => x.HealingDoneToBots).IsRequired();
            builder.Property(x => x.HealingDoneToSelf).IsRequired();
            builder.Property(x => x.LevelReached).IsRequired();
            builder.Property(x => x.MatchTeam).IsRequired();
            builder.Property(x => x.Surrendered).IsRequired();
            builder.Property(x => x.TeamId).IsRequired(false);
            builder.Property(x => x.TotalTimeDead).IsRequired();
            builder.Property(x => x.WardsPlaced).IsRequired();
            builder.Property(x => x.Winner).IsRequired();

            builder.HasOne(x => x.God)
                .WithMany(x => x.MatchDetails)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.GodSkin)
                .WithMany(x => x.MatchDetails)
                .HasForeignKey(x => x.GodSkinId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(x => x.Match)
                .WithMany(x => x.MatchDetails)
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(x => x.Player)
                .WithMany(x => x.MatchDetails)
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasMany(x => x.ActivePurchases)
                .WithOne(x => x.MatchDetail)
                .HasForeignKey(x => x.MatchDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ItemPurchases)
                .WithOne(x => x.MatchDetail)
                .HasForeignKey(x => x.MatchDetailId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
