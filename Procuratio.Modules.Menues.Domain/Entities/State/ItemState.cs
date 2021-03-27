﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ItemState : StateBaseEntity<int>
    {
        [StringLength(30)]
        public string Name { get; set; }

        public List<Item> Item { get; set; }
    }
}
