using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ExtraIngredient : BaseEntity<int>
    {
        [StringLength(30)]
        public string Name { get; set; }

        public decimal? MenuPrice { get; set; }

        public decimal? DinerInPrice { get; set; }

        public decimal? TakeAwayPrice { get; set; }

        public decimal? DeliveryPrice { get; set; }

        public List<ExtraIngredientXItem> ExtraIngredientXItem { get; set; }

        public int ExtraIngredientStateID { get; set; }
        public ExtraIngredientState ExtraIngredientState { get; set; }
    }
}
