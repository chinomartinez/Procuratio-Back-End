using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
