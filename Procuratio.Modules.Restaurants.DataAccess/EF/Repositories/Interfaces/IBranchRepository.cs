using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        Task<BranchForMenuModel> GetBranchForMenu(int branchId);
    }
}
