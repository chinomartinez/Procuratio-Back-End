﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities.State
{
    public class ExtraIngredientState
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public List<ExtraIngredient> ExtraIngredient { get; set; }

        public enum State
        {

        }
    }
}
