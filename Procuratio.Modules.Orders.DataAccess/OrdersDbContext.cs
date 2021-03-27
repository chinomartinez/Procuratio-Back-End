using Microsoft.EntityFrameworkCore;

namespace Procuratio.Modules.Orders.DataAccess
{
    public class OrdersDbContext : DbContext
    {
        // DbSet de orders...

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Orders");
            // ver si toma las configuraciones de las otras capas
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
