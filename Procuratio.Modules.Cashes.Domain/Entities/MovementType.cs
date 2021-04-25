using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MovementType : ManualBaseIdentity
    {
        public string Name { get; set; }

        public List<MountType> MountType { get; set; }

        public enum Type
        {
            Income = 1,
            Expenditure
        }
    }
}
