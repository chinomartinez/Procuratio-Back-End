using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.DTO
{
    public class SelectListItemDTO<TKey> 
    {
        public TKey ID { get; set; }

        public string Description { get; set; }
    }
}
