using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Customers.Domain.Entities.Intermediate;

namespace Procuratio.Modules.Customers.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    internal class CustomerXOrderConfiguration : IEntityTypeConfiguration<CustomerXOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerXOrder> builder)
        {
            builder.HasKey(x => new { x.CustomerID, x.OrderID });
        }
    }
}
