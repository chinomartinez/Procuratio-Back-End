using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using Procuratio.Modules.Restaurant.Service.Service.Interfaces;
using Procuratio.Modules.Restaurants.API.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.API.Controllers
{
    internal class BranchController : BaseController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("branch-for-menu/{branchId:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<BranchForMenuDTO>> GetBranchForMenu(int branchId)
        {
            return Ok(await _branchService.GetBranchForMenu(branchId));
        }
    }
}
