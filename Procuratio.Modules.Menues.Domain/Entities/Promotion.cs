using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Promotion : BaseEntity<int>
    {
        [StringLength(70)]
        public string Name { get; set; }

        public decimal? MenuPrice { get; set; }

        public decimal? DinerInPrice { get; set; }

        public decimal? TakeAwayPrice { get; set; }

        public decimal? DeliveryPrice { get; set; }

        public int PromotionOrder { get; set; }

        public int PromotionStateID { get; set; }
        public PromotionState PromotionState { get; set; }
    }
}
