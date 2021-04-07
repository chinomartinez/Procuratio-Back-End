using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ItemXPromotionState : StateBaseEntity
    {
        public List<ItemXPromotion> ItemsXPromotion { get; set; }

        public enum State
        {
            Disponible = 1,
            Eliminado
        }
    }
}
