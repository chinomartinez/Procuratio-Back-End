using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs
{
    public class MenuSubcategoryEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<MenuSubcategoryDTO>
    {
        public MenuSubcategoryDTO BaseProperties { get; set; }
    }
}
