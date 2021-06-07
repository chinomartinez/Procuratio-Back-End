using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.EntitiesConfigurations
{
    internal class BranchConfigurations : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(30).IsRequired();

            builder.Property(x => x.DateWithdrawn);
        }
    }
}
