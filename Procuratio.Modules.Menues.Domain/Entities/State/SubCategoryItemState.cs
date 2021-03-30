﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class SubCategoryItemState : StateBaseEntity<int>
    {
        public string Name { get; set; }

        public List<SubCategoryItem> SubCategoryItem { get; set; }
    }
}
