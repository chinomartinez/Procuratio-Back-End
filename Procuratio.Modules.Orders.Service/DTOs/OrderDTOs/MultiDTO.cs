using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class MultiDTO
    {
        public string Name { get; set; }

        public List<SeriesDTO> Series { get; set; }
    }
}
