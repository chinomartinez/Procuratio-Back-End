using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.BranchID).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
