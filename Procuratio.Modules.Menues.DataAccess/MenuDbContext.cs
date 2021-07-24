﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Menues.DataAccess
{
    internal class MenuDbContext : DbContext, ISeed
    {
        internal const string MenuSchemeName = "Menu";

        #region DbSet of entities
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<SubCategoryItem> SubCategoryItem { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        public DbSet<CategoryItemState> CategoryItemState { get; set; }
        public DbSet<ItemState> ItemState { get; set; }
        public DbSet<SubCategoryItemState> SubCategoryItemState { get; set; }
        #endregion

        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(MenuSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => MenuesSeedStart.CreateSeeds(this);
    }
}