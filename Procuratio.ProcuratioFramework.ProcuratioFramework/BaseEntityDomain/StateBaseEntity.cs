using System.ComponentModel.DataAnnotations;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class StateBaseEntity : ManualBaseIdentity<short>
    {
        [StringLength(30)]
        [Required]
        public string StateName { get; set; }
    }
}
