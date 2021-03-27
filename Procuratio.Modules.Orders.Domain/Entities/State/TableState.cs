﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TableState : StateBaseEntity<int>
    {
        [StringLength(30)]
        public string Name { get; set; }

        public List<Table> Table { get; set; }
    }
}
