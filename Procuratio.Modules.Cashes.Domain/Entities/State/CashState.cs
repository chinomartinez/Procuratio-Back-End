using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Cashes.Domain.Entities.State
{
    public class CashState : StateBaseEntity
    {
        public List<Cash> Cashes { get; set; }

        public enum State : short
        {
            Active = 1,
            Inactive,
            CashClosed
        }
    }
}
