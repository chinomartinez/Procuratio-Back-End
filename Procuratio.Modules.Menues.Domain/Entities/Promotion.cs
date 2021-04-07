using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Promotion : BaseEntity<int>
    {
        public string PromotionName { get; set; }

        public decimal? MenuPrice { get; set; }

        public decimal? DinerInPrice { get; set; }

        public decimal? TakeAwayPrice { get; set; }

        public decimal? DeliveryPrice { get; set; }

        public int PromotionOrder { get; set; }

        public int PromotionStateID { get; set; }
        public PromotionState PromotionState { get; set; }

        public List<PromotionDayOfWeek> PromotionsDayOfWeek { get; set; }

        public List<ItemXPromotion> ItemXPromotion { get; set; }
    }
}
