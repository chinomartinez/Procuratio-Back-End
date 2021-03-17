using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Promotion
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }

        [ItCantBeNegative]
        public decimal? MenuPrice { get; set; }

        [ItCantBeNegative]
        public decimal? DinerInPrice { get; set; }

        [ItCantBeNegative]
        public decimal? TakeAwayPrice { get; set; }

        [ItCantBeNegative]
        public decimal? DeliveryPrice { get; set; }

        [GreaterThanZero]
        public int PromotionOrder { get; set; }

        public int PromotionStateID { get; set; }
        public PromotionState PromotionState { get; set; }
    }
}
