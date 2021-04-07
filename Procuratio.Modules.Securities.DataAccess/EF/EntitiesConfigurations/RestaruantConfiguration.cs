using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations
{
    public class RestaruantConfiguration : IEntityTypeConfiguration<Restaruant>
    {
        public void Configure(EntityTypeBuilder<Restaruant> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
