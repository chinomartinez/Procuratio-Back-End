using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Procuratio.Modules.Orders.DataAccess.EF.Seeds;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess
{
    internal class OrderDbContext : DbContext, ISeed
    {
        internal const string OrderSchemeName = "Order";
        internal static int BranchId { get; private set; }

        #region DbSet of entities
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<WithoutReserve> WithoutReserve { get; set; }
        public DbSet<Domain.Entities.Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<TakeAway> TakeAway { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<TableXWithoutReserve> TableXWithoutReserve { get; set; }
        public DbSet<TableXReserve> TableXReserve { get; set; }
        #endregion

        #region DbSet of state entities
        public DbSet<DeliveryState> DeliveryState { get; set; }
        public DbSet<WithoutReserveState> WithoutReserveState { get; set; }
        public DbSet<OrderState> OrderState { get; set; }
        public DbSet<ReserveState> ReserveState { get; set; }
        public DbSet<TableState> TableState { get; set; }
        public DbSet<TakeAwayState> TakeAwayState { get; set; }
        #endregion

        public OrderDbContext(DbContextOptions<OrderDbContext> options, ITenantService tenantService) : base(options) 
        {
            BranchId = tenantService.GetBranchId();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(OrderSchemeName);
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
                    case EntityState.Added: entry.Entity.BranchId = BranchId;
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

        public void Seed() => OrdersSeedStart.CreateSeeds(this);
    }
}