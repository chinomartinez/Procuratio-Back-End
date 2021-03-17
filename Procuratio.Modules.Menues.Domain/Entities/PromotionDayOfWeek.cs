using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class PromotionDayOfWeek
    {
        public int ID { get; set; }

        public int PromotionID { get; set; }
        public List<Promotion> Promotion { get; set; }

        public PromotionDayOfWeekTimeRange PromotionDayOfWeekTimeRange { get; set; }
    }
}
