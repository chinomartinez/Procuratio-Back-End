using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class OrderNotFoundException : CustomExceptionBase
    {
        public int OrderID { get; }

        public OrderNotFoundException(int orderID) : base(message: $"Order with ID: '{orderID}' was not found.")
        {
            OrderID = orderID;
        }
    }
}
