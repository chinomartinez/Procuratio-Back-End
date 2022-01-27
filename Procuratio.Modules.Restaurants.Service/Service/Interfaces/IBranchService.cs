using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Service.Interfaces
{
    public interface IBranchService
    {
        Task<BranchForMenuDTO> GetBranchForMenu(int branchId);

        Task<List<SettingsDTO>> GetSettings(int branchId);
    }
}
