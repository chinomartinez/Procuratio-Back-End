using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TakeAwayState : StateBaseEntity
    {
        public List<TakeAway> TakeAways { get; set; }

        public enum State
        {
            Completado = 1,
            NoVino,
            Eliminado
        }
    }
}
