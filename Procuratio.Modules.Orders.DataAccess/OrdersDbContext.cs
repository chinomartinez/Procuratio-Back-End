using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Seeds;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Orders.DataAccess
{
    internal class OrdersDbContext : DbContext, ISeed
    {
        internal const string OrdersSchemeName = "Orders";

        #region DbSet of entities
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DineIn> DineIn { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<TakeAway> TakeAway { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<TableXDinerIn> TableXDineIn { get; set; }
        public DbSet<TableXReserve> TableXReserve { get; set; }
        #endregion

        #region DbSet of state entities
        public DbSet<DeliveryState> DeliveryState { get; set; }
        public DbSet<DineInState> DineInState { get; set; }
        public DbSet<OrderState> OrderState { get; set; }
        public DbSet<ReserveState> ReserveState { get; set; }
        public DbSet<TableState> TableState { get; set; }
        public DbSet<TakeAwayState> TakeAwayState { get; set; }
        #endregion

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(OrdersSchemeName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => OrdersSeedStart.CreateSeeds(this);
    }
}
