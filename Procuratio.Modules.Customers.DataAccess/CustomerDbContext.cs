using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.DataAccess.EF.Seeds;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Customers.DataAccess
{
    internal class CustomerDbContext : DbContext, ISeed
    {
        internal const string CustomerSchemeName = "Customer";
        private readonly ITenantService _tenantService;

        #region DbSet of entities
        public DbSet<Domain.Entities.Customer> Customer { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        #endregion

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options, ITenantService tenantService) : base(options) 
        {
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CustomerSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyTenantConfiguration(x => x.BranchId == _tenantService.GetBranchId());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int branchId = _tenantService.GetBranchId();

            foreach (var entry in ChangeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = branchId;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            int branchId = _tenantService.GetBranchId();

            foreach (var entry in ChangeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = branchId;
                        break;
                }
            }

            return base.SaveChanges();
        }

        public void Seed() => CustomersSeedStart.CreateSeeds(this);
    }
}
