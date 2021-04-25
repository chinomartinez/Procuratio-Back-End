﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Menues.DataAccess
{
    public class MenuesDbContext : DbContext, ISeed
    {
        internal const string MenuesSchemaName = "Menues";

        #region DbSet of entities
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<ExtraIngredient> ExtraIngredient { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<PromotionDayOfWeek> PromotionDayOfWeek { get; set; }
        public DbSet<PromotionDayOfWeekTimeRange> PromotionDayOfWeekTimeRange { get; set; }
        public DbSet<SubCategoryItem> SubCategoryItem { get; set; }
        public DbSet<ItemDrinkCapacity> ItemDrinkCapacity { get; set; }
        public DbSet<ItemSize> ItemSize { get; set; }
        public DbSet<UnitOfMeasureOfDrink> UnitOfMeasureOfDrink { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<ExtraIngredientXItem> ExtraIngredientXItem { get; set; }
        public DbSet<ItemXPromotion> ItemXPromotion { get; set; }
        public DbSet<ItemDrinkCapacityXItem> ItemDrinkCapacityXItem { get; set; }
        public DbSet<ItemSizeXItem> ItemSizeXItem { get; set; }
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
            modelBuilder.HasDefaultSchema(MenuesSchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => MenuesSeedStart.CreateSeeds(this);
    }
}
