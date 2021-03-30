using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
