﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.intermediate
{
    public class TableXDinerIn : IntermediateBaseEntity
    {
        public int DineInID { get; set; }
        public DineIn DineIn { get; set; }

        public int TableID { get; set; }
        public Table Table { get; set; }
    }
}
