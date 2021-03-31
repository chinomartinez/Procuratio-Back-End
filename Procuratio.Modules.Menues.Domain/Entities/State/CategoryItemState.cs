using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class CategoryItemState : StateBaseEntity
    {
        public List<CategoryItem> CategoryItem { get; set; }

        public enum State
        {

        }
    }
}
