using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateOrder
    {
        void SetFromwithoutStateToWithoutOrdering(Order order);
    }
}
