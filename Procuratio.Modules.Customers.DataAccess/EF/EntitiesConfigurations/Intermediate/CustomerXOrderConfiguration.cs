using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Customers.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    public class CustomerXOrderConfiguration : IEntityTypeConfiguration<CustomerXOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerXOrder> builder)
        {
            builder.HasKey(x => new { x.CustomerID, x.OrderID });
        }
    }
}
