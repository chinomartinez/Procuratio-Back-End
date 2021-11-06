using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces
{
    public interface IMenuSubcategoryRepository : IBaseRepositoryOperations<MenuSubcategory, int>
    {
        Task<int> GetNextOrder(int menuCategoryId);
    }
}
