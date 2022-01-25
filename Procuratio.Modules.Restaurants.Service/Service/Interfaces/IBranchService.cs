using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Service.Interfaces
{
    public interface IBranchService
    {
        Task<BranchForMenuDTO> GetBranchForMenu(int branchId);
    }
}
