using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces;

namespace Procuratio.Modules.Securities.Service.ValidateChangeState
{
    internal class ValidateChangeStateUser : IValidateChangeStateUser
    {
        public void SetFromWithoutStateToActive(User user)
        {
            bool isNewEntity = user.Id == 0;

            if (!isNewEntity)
            {
                // Throw exception
            }

            user.UserStateID = (short)UserState.State.Active;
        }
    }
}
