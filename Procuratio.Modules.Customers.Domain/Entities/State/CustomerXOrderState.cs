using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Customers.Domain.Entities.State
{
    public class CustomerXOrderState : StateBaseEntity
    {
        public List<CustomerXOrder> CustomersXOrders { get; set; }

        public enum State
        {
            Disponible = 1,
            Usado,
            Eliminado
        }
    }
}
