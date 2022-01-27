using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using Procuratio.Modules.Restaurant.Service.Service.Interfaces;
using Procuratio.Modules.Restaurants.API.Controllers.Base;
using Procuratio.Shared.Abstractions.Tenant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.API.Controllers
{
    internal class BranchController : BaseController
    {
        private readonly IBranchService _branchService;
        private readonly ITenantService _tenantService;

        public BranchController(IBranchService branchService, ITenantService tenantService)
        {
            _branchService = branchService;
            _tenantService = tenantService;
        }

        [HttpGet("for-menu/{branchId:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<BranchForMenuDTO>> GetBranchForMenu(int branchId)
        {
            return Ok(await _branchService.GetBranchForMenu(branchId));
        }

        [HttpGet("setting")]
        public async Task<ActionResult<List<SettingsDTO>>> GetSettings()
        {
            return Ok(await _branchService.GetSettings((int)_tenantService.GetBranchId()));
        }
    }
}
