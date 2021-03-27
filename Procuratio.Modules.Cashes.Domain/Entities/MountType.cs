using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MountType : BaseEntity<int>
    {
        [StringLength(30)]
        public string Name { get; set; }

        public MovementType MovementType { get; set; }

        public List<Cash> Cashes { get; set; }
    }
}
