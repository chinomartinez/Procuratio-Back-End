using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DinerInState : StateBaseEntity
    {
        public List<DinerIn> DinerIn { get; set; }

        public enum State
        {
            Completada = 1,
            Eliminado
        }
    }
}
