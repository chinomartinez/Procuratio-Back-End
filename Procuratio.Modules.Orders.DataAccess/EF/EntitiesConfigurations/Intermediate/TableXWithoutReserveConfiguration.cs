using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    internal class TableXWithoutReserveConfiguration : IEntityTypeConfiguration<TableXWithoutReserve>
    {
        public void Configure(EntityTypeBuilder<TableXWithoutReserve> builder)
        {
            builder.HasKey(x => new { x.WithoutReserveId, x.TableId });
        }
    }
}
