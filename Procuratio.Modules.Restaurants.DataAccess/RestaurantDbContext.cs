using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurants.DataAccess.EF.Seeds;
using Procuratio.Modules.Restaurants.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.DataAccess
{
    internal class RestaurantDbContext : DbContext, ISeed
    {
        internal const string RestaurantSchemeName = "Restaurant";
        internal static int BranchId { get; private set; }

        #region DbSet of entities
        public DbSet<Domain.Entities.Restaurant> Restaurant { get; set; }
        public DbSet<Branch> Branch { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        #endregion

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options, ITenantService tenantService) : base(options) 
        {
            BranchId = tenantService.GetBranchId();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(RestaurantSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyMultiTenantGlobalQueryFilter<IRestaurant>(e => e.BranchId == BranchId);
            modelBuilder.ApplyMultiTenantGlobalMetadata<IRestaurant>(nameof(BranchId));

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

        public void Seed() => RestaurantsSeedStart.CreateSeeds(this);
    }
}
