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

        public List<SeriesDTO> BestSellingItems { get; set; }

        public List<SeriesDTO> WorstSellingItems { get; set; }
    }
}
