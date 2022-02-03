using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces
{
    public interface IMenuCategoryRepository : IBaseRepositoryOperations<MenuCategory, int>
    {
        Task<int> GetNextOrderAsync();

        Task<List<MenuCategory>> GetAllAsync();

        Task<IReadOnlyList<MenuModel>> GetMenuAsync();

        Task<IReadOnlyList<OnlineMenuModel>> GetDineInOnlineMenuAsync(int branchId);

        Task<List<MenuCategory>> GetMenuToUpdateAsync();

        Task UpdateMenuAsync(List<MenuCategory> toUpdate);
    }
}
