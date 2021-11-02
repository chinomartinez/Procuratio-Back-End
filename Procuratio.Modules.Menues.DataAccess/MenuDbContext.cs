using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess
{
    internal class MenuDbContext : DbContext, ISeed
    {
        internal const string MenuSchemeName = "Menu";
        internal static int BranchId { get; private set; }

        #region DbSet of entities
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<ItemSubCategory> ItemSubCategory { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        public DbSet<ItemCategoryState> ItemCategoryState { get; set; }
        public DbSet<ItemState> ItemState { get; set; }
        public DbSet<ItemSubCategoryState> ItemSubCategoryState { get; set; }
        #endregion

        public MenuDbContext(DbContextOptions<MenuDbContext> options, ITenantService tenantService) : base(options) 
        {
            BranchId = tenantService.GetBranchId();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(MenuSchemeName);
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

        public void Seed() => MenuesSeedStart.CreateSeeds(this);
    }
}
