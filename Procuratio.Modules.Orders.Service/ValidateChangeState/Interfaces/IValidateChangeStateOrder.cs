using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateOrder
    {
        void SetFromwithoutStateToWithoutOrdering(Order order);
    }
}
