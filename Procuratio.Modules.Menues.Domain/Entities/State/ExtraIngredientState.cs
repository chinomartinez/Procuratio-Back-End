using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ExtraIngredientState : StateBaseEntity
    {
        public List<ExtraIngredient> ExtraIngredient { get; set; }

        public enum State
        {
            Available = 1,
            Deleted
        }
    }
}
