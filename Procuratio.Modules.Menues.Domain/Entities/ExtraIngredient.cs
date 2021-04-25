using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ExtraIngredient : BaseEntity<int>
    {
        public string ExtraIngredientName { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public decimal? PromotionPriceInsideRestaurant { get; set; }

        public decimal? PromotionPriceOutsideRestaurant { get; set; }

        public List<ExtraIngredientXItem> ExtraIngredientXItem { get; set; }

        public int ExtraIngredientStateID { get; internal set; }
        public ExtraIngredientState ExtraIngredientState { get; set; }
    }
}
