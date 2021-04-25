using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ItemSize : BaseEntity<int>
    {
        public int Size { get; set; }

        public List<ItemSizeXItem> ItemsSizeXItem { get; set; }
    }
}
