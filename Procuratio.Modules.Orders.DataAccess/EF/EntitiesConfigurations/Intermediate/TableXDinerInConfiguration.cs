using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    public class TableXDinerInConfiguration : IEntityTypeConfiguration<TableXDinerIn>
    {
        public void Configure(EntityTypeBuilder<TableXDinerIn> builder)
        {
            builder.HasKey(x => new { x.DinnerInID, x.TableID });
        }
    }
}
