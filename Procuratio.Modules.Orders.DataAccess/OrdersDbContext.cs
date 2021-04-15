﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Seeds;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Orders.DataAccess
{
    public class OrdersDbContext : DbContext, ISeed
    {
        internal const string OrdersSchemaName = "Orders";

        #region DbSet of entities
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DinerIn> DinerIn { get; set; }
        public DbSet<ItemInKitchen> ItemInKitchen { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<TakeAway> TakeAway { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<TableXDinerIn> TableXDinerIn { get; set; }
        public DbSet<TableXReserve> TableXReserve { get; set; }
        #endregion

        #region DbSet of state entities
        public DbSet<DeliveryState> DeliveryState { get; set; }
        public DbSet<DinerInState> DinerInState { get; set; }
        public DbSet<OrderState> OrderState { get; set; }
        public DbSet<ReserveState> ReserveState { get; set; }
        public DbSet<TableState> TableState { get; set; }
        public DbSet<TakeAwayState> TakeAwayState { get; set; }
        #endregion

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(OrdersSchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => OrdersSeedStart.CreateSeeds(this);
    }
}
