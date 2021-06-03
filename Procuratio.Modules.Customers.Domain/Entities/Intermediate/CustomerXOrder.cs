using Procuratio.Modules.Customers.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Runtime.CompilerServices;

namespace Procuratio.Modules.Customers.Domain.Entities.Intermediate
{
    public class CustomerXOrder : IntermediateBaseEntity
    {
        public int CustomerID { get; set; }
        public Customer MyProperty { get; set; }
        public int OrderID { get; set; }

        public short CustomerXOrderStateID { get; set; }
        public CustomerXOrderState CustomerXOrderState { get; set; }
    }
}
