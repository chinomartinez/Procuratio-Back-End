using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class DinerIn : BaseEntity<int>
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public short DinerInStateID { get; internal set; }
        public DinerInState DinerInState { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }
    }
}
