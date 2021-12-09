using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess
{
    internal class MenuDbContext : DbContext, ISeed
    {
        internal const string MenuSchemeName = "Menu";
        private readonly ITenantService _tenantService;

        #region DbSet of entities
        public DbSet<Item> Item { get; set; }
        public DbSet<MenuCategory> MenuCategory { get; set; }
        public DbSet<MenuSubcategory> MenuSubCategory { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        public DbSet<MenuCategoryState> MenuCategoryState { get; set; }
        public DbSet<ItemState> ItemState { get; set; }
        public DbSet<MenuSubCategoryState> MenuSubCategoryState { get; set; }
        #endregion

        public MenuDbContext(DbContextOptions<MenuDbContext> options, ITenantService tenantService) : base(options) 
        {
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(MenuSchemeName);
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

        public void Seed() => MenuesSeedStart.CreateSeeds(this);
    }
}
