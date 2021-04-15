using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class PromotionDayOfWeekTimeRange : BaseEntity<int>
    {
        public TimeSpan Begin { get; set; }

        public TimeSpan Finish { get; set; }

        public int DayNumberID { get; set; }
        public int PromotionID { get; set; }
        public PromotionDayOfWeek PromotionsDayOfWeek { get; set; }
    }
}
