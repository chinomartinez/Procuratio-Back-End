using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    public class PromotionDayOfWeekConfiguration : IEntityTypeConfiguration<PromotionDayOfWeek>
    {
        public void Configure(EntityTypeBuilder<PromotionDayOfWeek> builder)
        {
            builder.HasKey(x => new { x.PromotionID, x.DayNumber });
        }
    }
}
