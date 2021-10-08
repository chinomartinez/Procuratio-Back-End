using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderFromFormDTO : IFromFormDTO
    {
        [ModelBinder(typeof(TypeBinder<List<ItemForOrderFormDTO>>))]
        public List<ItemForOrderFormDTO> Items { get; set; }
    }
}
