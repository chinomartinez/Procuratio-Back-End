using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState
{
    internal class ValidateChangeStateOrder : IValidateChangeStateOrder
    {
        public void SetFromwithoutStateToWithoutOrdering(Order order)
        {
            order.OrderStateID = (short)OrderState.State.WithoutOrdering;
        }
    }
}
