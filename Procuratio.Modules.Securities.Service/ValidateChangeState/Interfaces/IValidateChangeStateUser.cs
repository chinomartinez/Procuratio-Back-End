using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateUser
    {
        void SetFromWithoutStateToActive(User user);
    }
}
