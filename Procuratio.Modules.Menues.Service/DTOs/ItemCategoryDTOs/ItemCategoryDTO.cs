using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemCategoryDTOs
{
    public class ItemCategoryDTO : IDTO
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public short ItemCategoryStateId { get; set; }
    }
}
