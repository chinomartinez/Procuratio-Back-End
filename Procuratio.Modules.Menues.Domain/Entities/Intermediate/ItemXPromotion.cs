using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Menues.Domain.Entities.Intermediate
{
    public class ItemXPromotion : IntermediateBaseEntity
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int PromotionID { get; set; }
        public Promotion Promotion { get; set; }

        public int ItemXPromotionOrder { get; set; }

        public ItemXPromotionState ItemXPromotionState { get; set; }
    }
}
