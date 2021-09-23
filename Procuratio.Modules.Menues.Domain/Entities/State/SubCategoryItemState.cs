using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class SubCategoryItemState : StateBaseEntity<SubCategoryItem>
    {
        public enum State : short
        {
            Available = 1,
            Deleted
        }
    }
}
