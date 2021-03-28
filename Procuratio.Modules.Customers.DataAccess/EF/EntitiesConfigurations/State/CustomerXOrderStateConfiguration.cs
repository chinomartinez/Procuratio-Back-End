using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Customers.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Customers.DataAccess.EF.EntitiesConfigurations.State
{
    public class CustomerXOrderStateConfiguration : IEntityTypeConfiguration<CustomerXOrderState>
    {
        public void Configure(EntityTypeBuilder<CustomerXOrderState> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
        }
    }
}
