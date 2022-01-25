using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.DbContextDbContextUtilities;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess
{
    internal class MenuDbContext : DbContext, ISeed
    {
        private readonly ITenantService _tenantService;

        #region DbSet of entities
        public DbSet<Item> Item { get; set; }
        public DbSet<MenuCategory> MenuCategory { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        public DbSet<MenuCategoryState> MenuCategoryState { get; set; }
        public DbSet<ItemState> ItemState { get; set; }
        #endregion

        public MenuDbContext(DbContextOptions<MenuDbContext> options, ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Menu");
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

        public void Seed() => MenuesSeedStart.CreateSeeds(this);
    }
}
