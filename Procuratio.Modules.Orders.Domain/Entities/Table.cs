﻿using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Table : BaseEntity<int>
    {
        public short Number { get; set; }

        public int Capacity { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }

        public int TableStateID { get; internal set; }
        public TableState TableState { get; set; }
    }
}
