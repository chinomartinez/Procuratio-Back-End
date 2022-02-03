using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.EntitiesConfigurations
{
    public class SettingConfigurations : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasData(new Setting()
            {
                Id = (short)Setting.Type.OnlineMenu,
                Description = "Online menu",
                Constrained = true,
                DataType = "boolean",
                MinValue = null,
                MaxValue = null
            },
            new Setting()
            {
                Id = (short)Setting.Type.OrderFromTable,
                Description = "Order from table",
                Constrained = true,
                DataType = "boolean",
                MinValue = null,
                MaxValue = null
            });
        }
    }
}
