using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;

namespace Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateUser
    {
        void SetFromWithoutStateToActive(User user);
    }
}
