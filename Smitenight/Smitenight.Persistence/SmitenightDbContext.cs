﻿using Microsoft.EntityFrameworkCore;
using Smitenight.Domain.Models.Abilities;
using Smitenight.Domain.Models.Gods;
using Smitenight.Domain.Models.Items;
using Smitenight.Domain.Models.Matches;
using Smitenight.Domain.Models.Players;

namespace Smitenight.Persistence
{
    public class SmitenightDbContext : DbContext
    {
        public SmitenightDbContext()
        {

        }

        public SmitenightDbContext(DbContextOptions<SmitenightDbContext> options) : base(options)
        {

        }

        public DbSet<Ability> Abilities => Set<Ability>();
        public DbSet<AbilityRank> AbilityRanks => Set<AbilityRank>();
        public DbSet<AbilityTag> AbilityTags => Set<AbilityTag>();

        public DbSet<BasicAttackDescription> BasicAttackDescriptions => Set<BasicAttackDescription>();
        public DbSet<God> Gods => Set<God>();
        public DbSet<GodBan> GodBans => Set<GodBan>();
        public DbSet<GodSkin> GodSkins => Set<GodSkin>();

        public DbSet<Active> Actives => Set<Active>();
        public DbSet<ActivePurchase> ActivePurchases => Set<ActivePurchase>();
        public DbSet<Consumable> Consumables => Set<Consumable>();
        public DbSet<ConsumableDescription> ConsumableDescriptions => Set<ConsumableDescription>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemDescription> ItemDescriptions => Set<ItemDescription>();
        public DbSet<ItemPurchase> ItemPurchases => Set<ItemPurchase>();

        public DbSet<Match> Matches => Set<Match>();
        public DbSet<MatchDetail> MatchDetails => Set<MatchDetail>();

        public DbSet<Player> Players => Set<Player>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmitenightDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if (DEBUG)
            optionsBuilder.EnableSensitiveDataLogging();
#endif
            base.OnConfiguring(optionsBuilder);
        }
    }
}
