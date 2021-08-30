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
        public int ID { get; set; }

        public string WaitersName { get; set; }

        public short DinerInStateID { get; set; }

        public string StateName { get; set; }

        public List<string> TableNumbers { get; set; }
    }
}
