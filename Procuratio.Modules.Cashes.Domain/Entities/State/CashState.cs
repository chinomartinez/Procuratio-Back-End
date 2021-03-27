﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Cashes.Domain.Entities.State
{
    public class CashState : StateBaseEntity<int>
    {
        [StringLength(30)]
        public string Name { get; set; }

        public List<Cash> Cashes { get; set; }
    }
}
