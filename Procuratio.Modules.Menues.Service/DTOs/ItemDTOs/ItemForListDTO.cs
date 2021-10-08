using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemForListDTO : IListDTO<ItemDTO>
    {
        public ItemDTO BaseProperties { get; set; }
    }
}
