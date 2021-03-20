using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MovementType
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public int MovementTypeID { get; set; }
        public MovementType MovementsType { get; set; }
    }
}
