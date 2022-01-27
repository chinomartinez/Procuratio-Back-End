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
    public class BranchSettingConfigurations : IEntityTypeConfiguration<BranchSetting>
    {
        public void Configure(EntityTypeBuilder<BranchSetting> builder)
        {
            builder.Property(x => x.UnconstrainedValue).IsRequired(false);
        }
    }
}
