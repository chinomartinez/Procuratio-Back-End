using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateTable
    {
        void SetFromwithoutStateToAvailable(Table table);
    }
}
