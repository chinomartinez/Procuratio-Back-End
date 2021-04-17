using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class CategoryItemState : StateBaseEntity
    {
        public List<CategoryItem> CategoryItem { get; set; }

        public enum State
        {
            Disponible = 1,
            Eliminado
        }
    }
}
