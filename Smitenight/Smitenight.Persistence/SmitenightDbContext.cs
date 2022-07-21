using Microsoft.EntityFrameworkCore;
using Smitenight.Domain.Models.Abilities;
using Smitenight.Domain.Models.Gods;
using Smitenight.Domain.Models.Items;

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


        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemDescription> ItemDescriptions => Set<ItemDescription>();

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
