using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Restaurant.Domain.Entities.intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    public class AllowedSettingValueConfigurations : IEntityTypeConfiguration<AllowedSettingValue>
    {
        public void Configure(EntityTypeBuilder<AllowedSettingValue> builder)
        {
        }
    }
}
