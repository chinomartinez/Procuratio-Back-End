using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities.Intermediate
{
    public class ExtraIngredientXItem
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int ExtraIngredientID { get; set; }
        public ExtraIngredient ExtraIngredient { get; set; }

        public int RestaurantID { get; set; }

        public int ExtraIngredientXItemStateID { get; set; }
        public ExtraIngredientXItemState ExtraIngredientXItemState { get; set; }
    }
}
