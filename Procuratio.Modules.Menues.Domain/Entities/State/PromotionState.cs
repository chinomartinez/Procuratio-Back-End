using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class PromotionState : StateBaseEntity
    {
        public List<Promotion> Promotions { get; set; }

        public enum State
        {
            Available = 1,
            Deleted
        }
    }
}
