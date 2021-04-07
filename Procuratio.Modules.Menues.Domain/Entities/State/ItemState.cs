using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ItemState : StateBaseEntity
    {
        public List<Item> Items { get; set; }

        public enum State
        {
            Disponible = 1,
            Eliminado
        }
    }
}
