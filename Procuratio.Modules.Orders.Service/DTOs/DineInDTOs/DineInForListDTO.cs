using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.DineInDTOs
{
    public class DineInForListDTO : IListDTO
    {
        public DineInDTO DineIn { get; set; } = new DineInDTO();

        public short OrderStateID { get; set; }

        public string WaitersName { get; set; }

        public string StateName { get; set; }

        public List<string> TableNumbers { get; set; } = new List<string>();
    }
}
