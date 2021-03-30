﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ExtraIngredientState : StateBaseEntity<int>
    {
        public string Name { get; set; }

        public List<ExtraIngredient> ExtraIngredient { get; set; }
    }
}
