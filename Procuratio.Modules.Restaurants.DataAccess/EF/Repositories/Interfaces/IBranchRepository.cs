using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurants.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        Task<BranchForMenuModel> GetBranchForMenu(int branchId);

        Task<List<SettingsModel>> GetSettings(int branchId);

        Task<Branch> GetBranchForUpdateSettings(int branchId);

        Task UpdateSettings(Branch branch);

        Task<bool> ExistBranchId(int branchId);
    }
}
