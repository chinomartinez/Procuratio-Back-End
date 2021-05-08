using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DeliveryState : StateBaseEntity
    {
        public List<Delivery> Deliveries { get; set; }

        public enum State : short
        {
            Completed = 1,
            InProgress
        }
    }
}
