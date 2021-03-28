using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.Domain.Entities;
using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using Procuratio.Modules.Customers.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Customers.DataAccess
{
    public class CustomersDbContext : DbContext
    {
        #region DbSet of entities
        public DbSet<Customer> Customer { get; set; }
        #endregion

        #region DbSet of intermediate entities
        public DbSet<CustomerXOrder> CustomerXOrder { get; set; }
        #endregion

        #region DbSet of state entities
        public DbSet<CustomerXOrderState> CustomerXOrderState { get; set; }
        #endregion

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Customers");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
