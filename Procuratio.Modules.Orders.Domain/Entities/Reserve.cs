﻿using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Reserve : BaseEntity<int>
    {
        public DateTime Date { get; set; }

        public short NumberOfDiners { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public short ReserveStateId { get; set; }
        public ReserveState ReserveState { get; set; }

        public int CustomerId { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }
    }
}
