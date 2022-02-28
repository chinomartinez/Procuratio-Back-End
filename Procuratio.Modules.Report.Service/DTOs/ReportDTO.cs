using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Report.Service.DTOs
{
    public class ReportDTO
    {
        public List<MultiDTO> OrderReport { get; set; }

        public List<SeriesDTO> BestSellingMeal { get; set; }

        public List<SeriesDTO> WorstSellingMeal { get; set; }

        public List<SeriesDTO> BestSellingDrink { get; set; }

        public List<SeriesDTO> WorstSellingDrink { get; set; }
    }
}
