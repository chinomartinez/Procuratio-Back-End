using Procuratio.Modules.Menu.Service.DTOs.ItemCategoryDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services.Interfaces
{
    public interface IItemCategoryService : IBaseServiceOperations<ItemCategoryDTO, ItemCategoryForListDTO, ItemCategoryFromFormDTO, ItemCategoryCreationFormInitializerDTO, ItemCategoryEditionFormInitializerDTO, int>
    {
    }
}
