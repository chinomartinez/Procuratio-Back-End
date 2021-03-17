using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class SubCategoryItem
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [GreaterThanZero]
        public int SubCategoryItemOrder { get; set; }

        public List<Item> Items { get; set; }

        public int SubCategoryItemStateID { get; set; }
        public SubCategoryItemState SubCategoryItemState { get; set; }

        public int CategoryID { get; set; }
        public CategoryItem Category { get; set; }
    }
}
