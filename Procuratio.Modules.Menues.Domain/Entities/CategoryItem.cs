using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class CategoryItem
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }

        public int CategoryItemStateID { get; set; }
        public CategoryItemState CategoryItemState { get; set; }

        public List<Item> Items { get; set; }

        public List<SubCategoryItem> SubCategoryItems { get; set; }
    }
}
