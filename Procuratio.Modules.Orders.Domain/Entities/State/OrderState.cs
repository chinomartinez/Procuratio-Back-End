using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class OrderState : StateBaseEntity
    {
        public List<Order> Orders { get; set; }

        public enum State
        {
            Pendiente = 1,
            EnProceso,
            ParaEntrega,
            Entregado,
            EsperandoPago,
            Eliminado,
            Completado
        }
    }
}
