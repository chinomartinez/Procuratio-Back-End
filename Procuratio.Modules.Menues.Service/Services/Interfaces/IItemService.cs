using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services.Interfaces
{
    public interface IItemService : IBaseServiceOperations<ItemDTO, ItemForListDTO, ItemFromFormDTO, ItemCreationFormInitializerDTO, ItemEditionFormInitializerDTO, int>
    {
        Task<IReadOnlyList<MenuDTO>> GetMenuAsync();

        Task<List<ItemDTO>> GetByIds(List<int> Ids);
    }
}
