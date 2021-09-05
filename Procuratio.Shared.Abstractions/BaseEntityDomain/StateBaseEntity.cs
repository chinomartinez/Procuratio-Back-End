using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class StateBaseEntity<TCollectionNavigationProperty> : ManualBaseIdentity<short>
    {
        public List<TCollectionNavigationProperty> CollectionNavigationProperty { get; set; }

        [StringLength(30)]
        [Required]
        public string StateName { get; set; }
    }
}
