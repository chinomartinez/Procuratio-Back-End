using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderFromFormDTO : IFromFormDTO
    {
        [ModelBinder(typeof(TypeBinder<List<ItemForOrderFormDTO>>))]
        public List<ItemForOrderFormDTO> Items { get; set; }
    }
}
