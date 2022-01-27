using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        Task<BranchForMenuModel> GetBranchForMenu(int branchId);

        Task<List<SettingsModel>> GetSettings(int branchId);
    }
}
