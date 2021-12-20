using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces
{
    public interface IMenuSubcategoryRepository : IBaseRepositoryOperations<MenuSubcategory, int>
    {
        Task<List<MenuSubcategory>> GetAllAsync();

        Task<int> GetNextOrderAsync(int menuCategoryId);
    }
}
