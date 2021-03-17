using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities.Intermediate
{
    public class ItemXPromotion
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int PromotionID { get; set; }
        public Promotion Promotion { get; set; }

        public int RestaurantID { get; set; }

        [GreaterThanZero]
        public int ItemXPromotionOrder { get; set; }

        public ItemXPromotionState ItemXPromotionState { get; set; }
    }
}
