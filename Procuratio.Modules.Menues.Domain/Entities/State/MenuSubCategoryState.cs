using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class MenuSubCategoryState : StateBaseEntity<MenuSubcategory>
    {
        public enum State : short
        {
            Available = 1,
            Deleted
        }
    }
}
