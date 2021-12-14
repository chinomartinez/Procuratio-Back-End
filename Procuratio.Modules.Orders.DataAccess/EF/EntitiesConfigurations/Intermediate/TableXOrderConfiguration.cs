using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Order.Domain.Entities.intermediate;

namespace Procuratio.Modules.Order.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    internal class TableXOrderConfiguration : IEntityTypeConfiguration<TableXOrder>
    {
        public void Configure(EntityTypeBuilder<TableXOrder> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.TableId });
        }
    }
}
