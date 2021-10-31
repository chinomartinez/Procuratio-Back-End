using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.BranchId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.HasQueryFilter(x => x.BranchId == OrderDbContext.BranchId);

            builder.HasIndex(x => new { x.BranchId, x.ItemId, x.OrderId }).IsUnique();

            builder.Property(x => x.Note).HasMaxLength(200);
        }
    }
}
