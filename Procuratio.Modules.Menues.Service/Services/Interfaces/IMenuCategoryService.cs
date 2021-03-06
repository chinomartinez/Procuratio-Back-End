using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services.Interfaces
{
    public interface IMenuCategoryService : IBaseServiceOperations<MenuCategoryDTO, MenuCategoryForListDTO, MenuCategoryFromFormDTO, MenuCategoryCreationFormInitializerDTO, MenuCategoryEditionFormInitializerDTO, int>
    {
        Task<IReadOnlyList<MenuDTO>> GetMenuAsync();

        Task<IReadOnlyList<OnlineMenuDTO>> GetDineInOnlineMenuAsync(int branchId);

        Task UpdateMenuAsync(List<MenuDTO> menuDTOs);
    }
}
