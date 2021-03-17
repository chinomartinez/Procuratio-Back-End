using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class PromotionDayOfWeekTimeRange
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public TimeSpan Begin { get; set; }

        public TimeSpan Finish { get; set; }

        public int DayOFweek { get; set; }

        public List<PromotionDayOfWeek> PromotionsDayOfWeek { get; set; }

        public List<ItemXPromotion> ItemXPromotion { get; set; }
    }
}
