using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class BaseEntity<TKey> : BaseIdentity<TKey>, IRestaurant
    {
        public int BranchID { get; set; }
    }
}
