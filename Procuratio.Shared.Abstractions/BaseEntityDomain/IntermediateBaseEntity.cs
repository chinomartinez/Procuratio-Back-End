using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class IntermediateBaseEntity : ITenant
    {
        [Required]
        [Range(1, double.MaxValue)]
        public int BranchId { get; set; }
    }
}
