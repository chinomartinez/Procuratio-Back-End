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
    public class ItemXPromotionConfiguration : IEntityTypeConfiguration<ItemXPromotion>
    {
        public void Configure(EntityTypeBuilder<ItemXPromotion> builder)
        {
            builder.HasKey(x => new { x.ItemID, x.PromotionID });
        }
    }
}
