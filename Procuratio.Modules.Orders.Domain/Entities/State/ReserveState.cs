using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class ReserveState : StateBaseEntity
    {
        public List<Reserve> Reserve { get; set; }

        public enum State
        {
            Pendiente = 1,
            SinConfirmar,
            Eliminada,
            Completada,
            NoVino
        }
    }
}
