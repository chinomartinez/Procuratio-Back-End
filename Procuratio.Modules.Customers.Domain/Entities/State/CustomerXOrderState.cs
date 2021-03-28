using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Customers.Domain.Entities.State
{
    public class CustomerXOrderState : StateBaseEntity<int>
    {
        public string Name { get; set; }

        public List<CustomerXOrder> CustomersXOrders { get; set; }
    }
}
