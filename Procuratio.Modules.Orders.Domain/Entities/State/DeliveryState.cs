using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DeliveryState
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public List<Delivery> Deliveries { get; set; }
    }
}
