using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.DataAccess.EF.Seeds;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Customers.DataAccess
{
    internal class CustomerDbContext : DbContext, ISeed
    {
        internal const string CustomerSchemeName = "Customer";

        #region DbSet of entities
        public DbSet<Domain.Entities.Customer> Customer { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        #endregion

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CustomerSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => CustomersSeedStart.CreateSeeds(this);
    }
}
