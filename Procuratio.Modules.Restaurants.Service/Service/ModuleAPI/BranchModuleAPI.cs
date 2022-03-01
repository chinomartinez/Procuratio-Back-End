using Procuratio.Modules.Restaurant.Service.Service.Interfaces;
using Procuratio.Modules.Restaurant.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Service.ModuleAPI
{
    internal class BranchModuleAPI : IBranchModuleAPI
    {
        private readonly IBranchService _branchService;

        public BranchModuleAPI(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<bool> ExistBranchId(int branchId)
        {
            return await _branchService.ExistBranchId(branchId);
        }
    }
}
