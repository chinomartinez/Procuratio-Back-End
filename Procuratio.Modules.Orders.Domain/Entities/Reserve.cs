using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Reserve
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public DateTime Date { get; set; }

        [GreaterThanZero]
        public short NumberOfDiners { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int UserID { get; set; }
        //public User User { get; set; }

        public int ReserveStateID { get; set; }
        public ReserveState ReserveState { get; set; }

        public int CustomerID { get; set; }
        //public Customer Customer { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }
    }
}
