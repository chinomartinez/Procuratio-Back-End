using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations.Intermediate
{
    public class ExtraIngredientXItemConfiguration : IEntityTypeConfiguration<ExtraIngredientXItem>
    {
        public void Configure(EntityTypeBuilder<ExtraIngredientXItem> builder)
        {
            builder.HasKey(x => new { x.ExtraIngredientID, x.ItemID });
        }
    }
}
