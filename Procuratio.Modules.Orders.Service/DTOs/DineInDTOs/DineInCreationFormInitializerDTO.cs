using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.DineInDTOs
{
    public class DineInCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
    {
        public List<SelectListItemDTO<int>> Tables { get; set; } = new List<SelectListItemDTO<int>>();
    }
}
