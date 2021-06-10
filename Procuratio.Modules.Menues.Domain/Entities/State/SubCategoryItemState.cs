using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class SubCategoryItemState : StateBaseEntity
    {
        public List<SubCategoryItem> SubCategoryItem { get; set; }

        public enum State : short
        {
            Available = 1,
            Deleted
        }
    }
}
