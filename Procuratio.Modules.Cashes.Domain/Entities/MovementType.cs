using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MovementType : BaseIdentity<int>
    {
        public string Name { get; set; }

        public List<MountType> MountType { get; set; }
    }
}
