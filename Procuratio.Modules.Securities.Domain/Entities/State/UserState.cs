using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
