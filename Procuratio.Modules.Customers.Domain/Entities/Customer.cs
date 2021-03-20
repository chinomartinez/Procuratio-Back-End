using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Customers.Domain.Entities
{
    public class Customer
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(10)]
        public string CellPhone { get; set; }
    }
}
