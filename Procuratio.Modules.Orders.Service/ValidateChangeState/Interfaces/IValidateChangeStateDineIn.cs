using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateDineIn
    {
        void SetFromWithoutStateToInProgress(DineIn dineIn);
    }
}
