using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class OrderState : StateBaseEntity
    {
        public List<Order> Orders { get; set; }

        public enum State : short
        {
            WithoutOrdering = 1,
            InProgress,
            ForDelivery,
            Delivered
        }
    }
}
