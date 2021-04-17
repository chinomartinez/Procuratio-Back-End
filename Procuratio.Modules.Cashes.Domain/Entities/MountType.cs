using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MountType : BaseEntity<int>
    {
        public string Name { get; set; }

        public MovementType MovementType { get; set; }

        public List<Cash> Cashes { get; set; }
    }
}
