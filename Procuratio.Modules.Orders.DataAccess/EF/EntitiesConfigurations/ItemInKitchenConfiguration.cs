using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    public class ItemInKitchenConfiguration : IEntityTypeConfiguration<ItemInKitchen>
    {
        public void Configure(EntityTypeBuilder<ItemInKitchen> builder)
        {
            builder.HasKey(x => new { x.OrderDetailID, x.ItemID });
        }
    }
}
