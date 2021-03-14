using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class OrderDetail
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [GreaterThanZero]
        public int Quantity { get; set; }

        public int? ItemID { get; set; }
        //public Item? Item { get; set; }

        public int? PromotionID { get; set; }
        //public Promotion? Promotion { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public ItemInKitchen ItemInKitchen { get; set; }
    }
}
