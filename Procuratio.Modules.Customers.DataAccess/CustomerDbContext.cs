using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.DataAccess.EF.Seeds;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Customers.DataAccess
{
    internal class CustomerDbContext : DbContext, ISeed
    {
        internal const string CustomerSchemeName = "Customer";
        internal static int BranchId { get; private set; }

        #region DbSet of entities
        public DbSet<Domain.Entities.Customer> Customer { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        #endregion

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, ITenantService tenantService) : base(options) 
        {
            BranchId = tenantService.GetBranchId();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CustomerSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IRestaurant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = BranchId;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IRestaurant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = BranchId;
                        break;
                }
            }

            int result = base.SaveChanges();

            return result;
        }

        public void Seed() => CustomersSeedStart.CreateSeeds(this);
    }
}
