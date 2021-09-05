using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class OrderState : StateBaseEntity<Order>
    {
        public enum State : short
        {
            Pending = 1,
            InProgress,
            ForDelivery,
            Delivered
        }
    }
}
