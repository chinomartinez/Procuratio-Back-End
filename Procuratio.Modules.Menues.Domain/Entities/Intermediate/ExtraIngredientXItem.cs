using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Menues.Domain.Entities.Intermediate
{
    public class ExtraIngredientXItem : IntermediateBaseEntity
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int ExtraIngredientID { get; set; }
        public ExtraIngredient ExtraIngredient { get; set; }

        public bool ItsFree { get; set; }

        public int ExtraIngredientXItemStateID { get; set; }
        public ExtraIngredientXItemState ExtraIngredientXItemState { get; set; }
    }
}
