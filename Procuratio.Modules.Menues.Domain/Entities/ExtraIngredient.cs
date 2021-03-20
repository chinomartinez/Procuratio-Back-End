using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ExtraIngredient
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [GreaterThanZero]
        public decimal? MenuPrice { get; set; }

        [GreaterThanZero]
        public decimal? DinerInPrice { get; set; }

        [GreaterThanZero]
        public decimal? TakeAwayPrice { get; set; }

        [GreaterThanZero]
        public decimal? DeliveryPrice { get; set; }

        public List<ExtraIngredientXItem> ExtraIngredientXItem { get; set; }

        public int ExtraIngredientStateID { get; set; }
        public ExtraIngredientState ExtraIngredientState { get; set; }
    }
}
