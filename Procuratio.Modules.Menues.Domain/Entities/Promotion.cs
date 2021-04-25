using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Promotion : BaseEntity<int>
    {
        public string PromotionName { get; set; }

        public int PromotionOrder { get; set; }

        public int PromotionStateID { get; internal set; }
        public PromotionState PromotionState { get; set; }

        public List<PromotionDayOfWeek> PromotionsDayOfWeek { get; set; }

        public List<ItemXPromotion> ItemsXPromotion { get; set; }
    }
}
