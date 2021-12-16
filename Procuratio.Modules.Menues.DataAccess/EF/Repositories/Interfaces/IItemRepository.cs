using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces
{
    public interface IItemRepository : IBaseRepositoryOperations<Item, int>
    {
        Task<int> GetNextOrderAsync(int menuSubcategoryId);

        Task<IReadOnlyList<Item>> GetMenuAsync();

        Task<List<MenuForOrderDetail>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn);
    }
}
