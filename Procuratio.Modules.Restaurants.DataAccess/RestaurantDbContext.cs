using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurants.DataAccess.EF.Seeds;
using Procuratio.Modules.Restaurants.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.DbContextDbContextUtilities;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.DataAccess
{
    internal class RestaurantDbContext : DbContext, ISeed
    {
        private readonly ITenantService _tenantService;

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
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Restaurant");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.ApplyTenantConfiguration(x => x.BranchId == _tenantService.GetBranchId());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            DbContextSupportMethods.BeforeSaveChanges(ChangeTracker, _tenantService);
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            DbContextSupportMethods.BeforeSaveChanges(ChangeTracker, _tenantService);
            return base.SaveChanges();
        }

        public void Seed() => RestaurantsSeedStart.CreateSeeds(this);
    }
}
