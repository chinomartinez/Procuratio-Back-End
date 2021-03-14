using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Table
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [Required]
        [GreaterThanZero]
        public short Number { get; set; }

        [Required]
        [GreaterThanZero]
        public int Capacity { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }

        public TableState TableState { get; set; }
    }
}
