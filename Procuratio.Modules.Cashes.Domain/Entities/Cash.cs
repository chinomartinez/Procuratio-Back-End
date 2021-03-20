using Procuratio.Modules.Cashes.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class Cash
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public DateTime Date { get; set; }

        [ItCantBeNegative]
        public decimal Mount { get; set; }

        [StringLength(100)]
        public string Detail { get; set; }

        public int OrderID { get; set; }

        public int MountTypeID { get; set; }
        public MountType MountType { get; set; }

        public int CashStateID { get; set; }
        public CashState CashState { get; set; }

        public int UserID { get; set; }
    }
}
