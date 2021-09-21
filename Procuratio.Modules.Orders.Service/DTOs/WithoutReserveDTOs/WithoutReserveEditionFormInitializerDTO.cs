using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveEditionFormInitializerDTO : IEntityEditionFormInitializerDTO
    {
        public WithoutReserveDTO WithoutReserve { get; set; }

        public MultipleSelectListItemForEditionDTO Tables { get; set; } = new MultipleSelectListItemForEditionDTO();
    }
}
