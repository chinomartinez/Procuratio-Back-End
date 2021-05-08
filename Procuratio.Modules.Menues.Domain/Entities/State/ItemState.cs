using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ItemState : StateBaseEntity
    {
        public List<Item> Items { get; set; }

        public enum State : short
        {
            Available = 1,
            Deleted
        }
    }
}
