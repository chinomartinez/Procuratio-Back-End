using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState
{
    internal class ValidateChangeStateDineIn : IValidateChangeStateDineIn
    {
        public void SetFromWithoutStateToInProgress(DineIn dineIn)
        {
            bool isNewEntity = dineIn.ID == 0;

            if (!isNewEntity)
            {
                // Throw exception
            }

            dineIn.DinerInStateID = (short)DineInState.State.InProgress;
        }
    }
}
