using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class UpdateTableDTO
    {
        public int ID { get; set; }
        public int Capacity { get; set; }
        public short TableStateID { get; set; }
    }
}
