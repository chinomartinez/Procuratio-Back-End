using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    internal class TableXDineInConfiguration : IEntityTypeConfiguration<TableXDinerIn>
    {
        public void Configure(EntityTypeBuilder<TableXDinerIn> builder)
        {
            builder.Property(x => x.BranchID).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasKey(x => new { x.DinnerInID, x.TableID });
        }
    }
}
