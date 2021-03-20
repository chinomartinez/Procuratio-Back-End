using Procuratio.Modules.Customers.Domain.Entities.Intermediate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Customers.Domain.Entities.State
{
    public class CustomerXOrderState
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string MyProperty { get; set; }

        public List<CustomerXOrder> CustomersXOrders { get; set; }
    }
}
