using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Securities.Domain.Entities.State
{
    public class UserState : StateBaseEntity
    {
        public List<User> Users { get; set; }

        public enum State : short
        {
            Active = 1,
            Withdrawn
        }
    }
}
