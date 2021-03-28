using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Configurations.State
{
    public class DeliveryStateConfiguration : IEntityTypeConfiguration<DeliveryState>
    {
        public void Configure(EntityTypeBuilder<DeliveryState> builder)
        {
        }
    }
}
