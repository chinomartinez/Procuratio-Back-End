using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class PromotionDayOfWeek : CompoundKeyBaseEntity
    {
        public int DayNumber { get; set; }

        public int PromotionID { get; set; }
        public Promotion Promotion { get; set; }

        public List<PromotionDayOfWeekTimeRange> PromotionsDayOfWeekTimeRange { get; set; }
    }
}
