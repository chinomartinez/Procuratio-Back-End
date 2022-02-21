using Procuratio.Modules.Report.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Report.Service.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<MultiDTO>> GetOrderForReport(int from , int to);
    }
}
