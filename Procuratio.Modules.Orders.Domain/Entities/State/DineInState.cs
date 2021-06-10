using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DineInState : StateBaseEntity
    {
        public List<DineIn> DinerIn { get; set; }

        public enum State : short
        {
            Completed = 1,
            InProgress
        }
    }
}
