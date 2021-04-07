using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess
{
    public class MenuesDbContext : DbContext, ISeed
    {
        #region DbSet of entities
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredient { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<PromotionDayOfWeek> PromotionDayOfWeek { get; set; }
        public DbSet<PromotionDayOfWeekTimeRange> PromotionDayOfWeekTimeRange { get; set; }
        public DbSet<SubCategoryItem> SubCategoryItem { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<ExtraIngredientXItem> ExtraIngredientXItem { get; set; }
        public DbSet<ItemXPromotion> ItemXPromotion { get; set; }
        #endregion

        #region DbSet of state entities
        public DbSet<CategoryItemState> CategoryItemState { get; set; }
        public DbSet<ExtraIngredientState> ExtraIngredientState { get; set; }
        public DbSet<ExtraIngredientXItemState> ExtraIngredientXItemState { get; set; }
        public DbSet<ItemState> ItemState { get; set; }
        public DbSet<ItemXPromotionState> ItemXPromotionState { get; set; }
        public DbSet<PromotionState> PromotionState { get; set; }
        public DbSet<SubCategoryItemState> SubCategoryItemState { get; set; }
        #endregion

        public MenuesDbContext(DbContextOptions<MenuesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Menues");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => MenuesSeedStart.CreateSeeds(this);
    }
}
