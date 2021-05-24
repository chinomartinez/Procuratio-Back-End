using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.EntitiesConfigurations
{
    public class RestaurantPhoneConfiguration : IEntityTypeConfiguration<RestaurantPhone>
    {
        public void Configure(EntityTypeBuilder<RestaurantPhone> builder)
        {
            builder.Property(x => x.Phone).HasMaxLength(10).IsRequired();
        }
    }
}
