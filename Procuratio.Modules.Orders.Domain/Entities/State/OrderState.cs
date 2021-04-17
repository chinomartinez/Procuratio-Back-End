using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class OrderState : StateBaseEntity
    {
        public List<Order> Orders { get; set; }

        public enum State
        {
            EnProceso = 1,
            ParaEntrega,
            Entregado
        }
    }
}
