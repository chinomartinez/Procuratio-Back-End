using Procuratio.Modules.Customers.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Customers.Domain.Entities.Intermediate
{
    public class CustomerXOrder
    {
        public int CustomerID { get; set; }
        public Customer MyProperty { get; set; }
        public int OrderID { get; set; }

        public int CustomerXOrderStateID { get; set; }
        public CustomerXOrderState CustomerXOrderState { get; set; }
    }
}
