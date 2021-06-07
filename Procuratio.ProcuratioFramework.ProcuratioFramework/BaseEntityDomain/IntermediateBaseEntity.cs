using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class IntermediateBaseEntity : IRestaurant
    {
        public int BranchID { get; set; }
    }
}
