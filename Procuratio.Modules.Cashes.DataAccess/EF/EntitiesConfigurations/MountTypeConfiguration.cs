using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Cashes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.EntitiesConfigurations
{
    public class MountTypeConfiguration : IEntityTypeConfiguration<MountType>
    {
        public void Configure(EntityTypeBuilder<MountType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
