using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.DTO.OrderDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.DineInDTOs
{
    public class DineInFromFormDTO : IFromFormDTO
    {
        [ModelBinder(binderType: typeof(TypeBinder<List<int>>))]
        public List<int> TablesIds { get; set; }

        public OrderDTO Order { get; set; }
    }
}
