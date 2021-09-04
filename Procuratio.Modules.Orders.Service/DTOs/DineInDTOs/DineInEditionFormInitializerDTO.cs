using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using Procuratio.Shared.ProcuratioFramework.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.DineInDTOs
{
    public class DineInEditionFormInitializerDTO : IEntityEditionFormInitializerDTO
    {
        public DineInDTO DineIn { get; set; }

        public MultipleSelectListItemForEditionDTO<int> Tables { get; set; } = new MultipleSelectListItemForEditionDTO<int>();
    }
}
