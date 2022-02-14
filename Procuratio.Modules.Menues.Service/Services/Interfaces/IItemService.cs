using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menu.Shared.DTO;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services.Interfaces
{
    public interface IItemService : IBaseServiceOperations<ItemDTO, ItemForListDTO, ItemFromFormDTO, ItemCreationFormInitializerDTO, ItemEditionFormInitializerDTO, int>
    {
        Task<IReadOnlyList<MenuAddItemsToOrderVM>> GetMenuAddItemsToOrderAsync(List<int> ids);

        Task<List<ItemDTO>> GetByIds(List<int> Ids);

        Task<List<MenuForOrderDetailDTO>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn);

        Task<List<ItemsForOrderDetailInKitchenDTO>> GetItemsForKitchenAsync(List<int> itemIds);

        Task<List<ItemsForBillDTO>> GetItemsFoBillAsync(List<int> itemIds, bool dineIn);

        Task<List<ItemsForBillDTO>> GetAnonymousItemsFoBillAsync(List<int> itemIds, int branchId);
    }
}
