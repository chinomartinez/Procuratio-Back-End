using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Configurations.State
{
    public class ReserveStateConfiguration : IEntityTypeConfiguration<ReserveState>
    {
        public void Configure(EntityTypeBuilder<ReserveState> builder)
        {
        }
    }
}
