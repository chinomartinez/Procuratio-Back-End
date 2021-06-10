using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.DataAccess.EF.Seeds;
using Procuratio.Modules.Customers.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Customers.DataAccess
{
    internal class CustomersDbContext : DbContext, ISeed
    {
        internal const string CustomersSchemeName = "Customers";

        #region DbSet of entities
        public DbSet<Customer> Customer { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        #endregion

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CustomersSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => CustomersSeedStart.CreateSeeds(this);
    }
}
