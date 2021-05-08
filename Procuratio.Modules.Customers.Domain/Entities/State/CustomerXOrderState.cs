using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Customers.Domain.Entities.State
{
    public class CustomerXOrderState : StateBaseEntity
    {
        public List<CustomerXOrder> CustomersXOrders { get; set; }

        public enum State : short
        {
            Available = 1,
            Used,
            Deleted
        }
    }
}
