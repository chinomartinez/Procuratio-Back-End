using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DeliveryState
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string MyProperty { get; set; }

        public List<Delivery> Deliveries { get; set; }

        public enum State
        {

        }
    }
}
