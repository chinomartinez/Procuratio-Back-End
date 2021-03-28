using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Configurations
{
    public class ItemInKitchenConfiguration : IEntityTypeConfiguration<ItemInKitchen>
    {
        public void Configure(EntityTypeBuilder<ItemInKitchen> builder)
        {
            builder.HasKey(x => new { x.OrderDetailID, x.ItemID });
        }
    }
}
