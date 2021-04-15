using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.DataAccess.EF.Seeds;
using Procuratio.Modules.Customers.Domain.Entities;
using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using Procuratio.Modules.Customers.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Customers.DataAccess
{
    public class CustomersDbContext : DbContext, ISeed
    {
        internal const string CustomersSchemaName = "Customers";

        #region DbSet of entities
        public DbSet<Customer> Customer { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<CustomerXOrder> CustomerXOrder { get; set; }
        #endregion

        #region DbSet of state entities
        public DbSet<CustomerXOrderState> CustomerXOrderState { get; set; }
        #endregion

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CustomersSchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => CustomersSeedStart.CreateSeeds(this);
    }
}
