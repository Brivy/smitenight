﻿using Microsoft.EntityFrameworkCore;
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
            builder.Property(x => x.AutoBanned).IsRequired();
            builder.Property(x => x.GodCardUrl).IsRequired();
            builder.Property(x => x.GodIconUrl).IsRequired();
            builder.Property(x => x.LatestGod).IsRequired();
            builder.Property(x => x.Lore).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.OnFreeRotation).IsRequired();
            builder.Property(x => x.Pantheon).IsRequired();
            builder.Property(x => x.Pros).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.SmiteId).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasMany(x => x.Abilities)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.BasicAttackDescriptions)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.GodBans)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.GodSkins)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.MatchDetails)
                .WithOne(x => x.God)
                .HasForeignKey(x => x.GodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
