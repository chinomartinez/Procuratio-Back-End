using Procuratio.Modules.Customers.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Customers.Domain.Entities.Intermediate
{
    public class CustomerXOrder : IntermediateBaseEntity
    {
        public int CustomerID { get; set; }
        public Customer MyProperty { get; set; }
        public int OrderID { get; set; }

        public int CustomerXOrderStateID { get; set; }
        public CustomerXOrderState CustomerXOrderState { get; set; }
    }
}
