using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    internal class TableXReserveConfiguration : IEntityTypeConfiguration<TableXReserve>
    {
        public void Configure(EntityTypeBuilder<TableXReserve> builder)
        {
            builder.HasKey(x => new { x.ReserveID, x.TableID });
        }
    }
}
