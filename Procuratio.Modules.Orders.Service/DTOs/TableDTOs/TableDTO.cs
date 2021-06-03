using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class TableDTO
    {
        public short Number { get; set; }

        public int Capacity { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }

        public int TableStateID { get; set; }
        public TableState TableState { get; set; }
    }
}
