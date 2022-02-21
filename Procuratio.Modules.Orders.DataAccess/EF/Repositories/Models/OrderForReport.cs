using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Models
{
    public class OrderForReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Quantity { get; set; }
    }
}
