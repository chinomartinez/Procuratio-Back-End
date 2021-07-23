using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.DTO.OrderDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Service.DTOs.DinerInDTOs
{
    public class AddDineInDTO : IAddDTO
    {

        [ModelBinder(binderType: typeof(TypeBinder<List<int>>))]
        public List<int> TablesIds { get; set; }

        public OrderDTO Order { get; set; }
    }
}
