using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ExtraIngredientXItemState : StateBaseEntity
    {
        public List<ExtraIngredientXItem> ExtraIngredientXItem { get; set; }

        public enum State
        {
            Available = 1,
            Deleted
        }
    }
}
