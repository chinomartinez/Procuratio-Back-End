﻿using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class TableDTO : IDTO
    {
        public short Number { get; set; }

        public int Capacity { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }

        public int TableStateID { get; set; }
        public TableState TableState { get; set; }
    }
}
