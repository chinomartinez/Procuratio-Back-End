using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class SettingSeed
    {
        internal static void StartSettingSeed(DbSet<Setting> settingDbSet)
        {
            if (settingDbSet.Any()) return;

            settingDbSet.AddRange(new Setting()
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
