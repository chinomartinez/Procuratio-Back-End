using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Securities.Domain.Entities.State
{
    public class UserState : StateBaseEntity<User>
    {
        public enum State : short
        {
            Active = 1,
            Withdrawn
        }
    }
}
