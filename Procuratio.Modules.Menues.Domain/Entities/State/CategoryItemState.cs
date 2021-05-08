using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class CategoryItemState : StateBaseEntity
    {
        public List<CategoryItem> CategoryItem { get; set; }

        public enum State : short
        {
            Available = 1,
            Deleted
        }
    }
}
