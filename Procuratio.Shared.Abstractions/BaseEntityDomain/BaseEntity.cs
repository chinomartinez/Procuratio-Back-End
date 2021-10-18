using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class BaseEntity<TKey> : BaseIdentity<TKey>, IRestaurant
    {
        [Required]
        [Range(1, double.MaxValue)]
        public int BranchId { get; set; }
    }
}
