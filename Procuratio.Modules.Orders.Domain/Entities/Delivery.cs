using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Delivery
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "La dirección de destino es requerida")]
        [StringLength(maximumLength: 100, ErrorMessage = "La dirección de destino no puede superar los 100 caracteres")]
        public string DestinyDirection { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int DeliveryStateID { get; set; }
        public DeliveryState DeliveryState { get; set; }
    }
}
