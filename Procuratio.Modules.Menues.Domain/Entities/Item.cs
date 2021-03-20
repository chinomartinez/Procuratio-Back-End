﻿using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Item
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int MyProperty { get; set; }

        [GreaterThanZero]
        public decimal? MenuPrice { get; set; }

        [GreaterThanZero]
        public decimal? DinerInPrice { get; set; }

        [GreaterThanZero]
        public decimal? TakeAwayPrice { get; set; }

        [GreaterThanZero]
        public decimal? DeliveryPrice { get; set; }

        public bool ForKitchen { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [GreaterThanZero]
        public int ItemOrder { get; set; }

        public int ItemStateID { get; set; }
        public ItemState ItemState { get; set; }

        public int? CategoryItemID { get; set; }
        public CategoryItem CategoryItem { get; set; }

        public int? SubCategoryItemID { get; set; }
        public SubCategoryItem SubCategoryItem { get; set; }

        public List<ExtraIngredientXItem> ExtrasIngredientsXItem { get; set; }


        public List<ItemXPromotion> ItemsXPromotions { get; set; }
    }
}
