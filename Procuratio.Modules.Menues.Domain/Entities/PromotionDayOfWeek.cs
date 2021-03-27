using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class PromotionDayOfWeek : BaseEntity<int>
    {
        public int PromotionID { get; set; }
        public List<Promotion> Promotion { get; set; }

        public PromotionDayOfWeekTimeRange PromotionDayOfWeekTimeRange { get; set; }
    }
}
