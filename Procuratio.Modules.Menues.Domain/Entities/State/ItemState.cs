using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ItemState : StateBaseEntity
    {
        public List<Item> Items { get; set; }

        public enum State
        {
            Available = 1,
            Deleted
        }
    }
}
