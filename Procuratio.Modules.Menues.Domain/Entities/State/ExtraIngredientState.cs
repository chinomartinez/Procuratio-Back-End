using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ExtraIngredientState : StateBaseEntity
    {
        public List<ExtraIngredient> ExtraIngredient { get; set; }

        public enum State
        {
            Disponible = 1,
            Eliminado
        }
    }
}
