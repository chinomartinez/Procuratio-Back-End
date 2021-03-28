using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Configurations.Intermediate
{
    public class TableXReserveConfiguration : IEntityTypeConfiguration<TableXReserve>
    {
        public void Configure(EntityTypeBuilder<TableXReserve> builder)
        {
            builder.HasKey(x => new { x.ReserveID, x.TableID });
        }
    }
}
