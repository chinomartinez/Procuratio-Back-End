using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Report.API.Controllers.Base;
using Procuratio.Modules.Report.Service.DTOs;
using Procuratio.Modules.Report.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Report.API.Controllers
{
    internal class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("report/{from:int}/{to:int}/{topBestSellingItems:int}/{topWorstSellingItems:int}")]
        public async Task<ActionResult<ReportDTO>> GetOrderForReport(int from, int to, int topBestSellingItems, int topWorstSellingItems)
        {
            return Ok(await _reportService.GetOrderForReport(from, to, topBestSellingItems, topWorstSellingItems));
        }
    }
}
