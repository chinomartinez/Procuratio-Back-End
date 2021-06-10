using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurants.DataAccess.EF.Seeds;
using Procuratio.Modules.Restaurants.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Restaurants.DataAccess
{
    internal class RestaurantsDbContext : DbContext, ISeed
    {
        internal const string RestaurantsSchemeName = "Restaurants";

        #region DbSet of entities
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Branch> Branch { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        #endregion

        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(RestaurantsSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => RestaurantsSeedStart.CreateSeeds(this);
    }
}
