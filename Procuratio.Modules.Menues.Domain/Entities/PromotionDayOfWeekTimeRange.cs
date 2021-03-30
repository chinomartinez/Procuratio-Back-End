using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class PromotionDayOfWeekTimeRange : BaseEntity<int>
    {
        public TimeSpan Begin { get; set; }

        public TimeSpan Finish { get; set; }

        public int DayOFweek { get; set; }

        public List<PromotionDayOfWeek> PromotionsDayOfWeek { get; set; }

        public List<ItemXPromotion> ItemXPromotion { get; set; }
    }
}
