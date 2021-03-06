using Procuratio.Modules.Menu.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Shared
{
    public interface IItemModuleAPI
    {
        Task<List<MenuForOrderDetailDTO>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn);

        Task<List<ItemsForOrderDetailInKitchenDTO>> GetItemsForKitchenAsync(List<int> itemIds);

        Task<List<ItemsForBillDTO>> GetItemsForBillAsync(List<int> itemIds, bool dineIn);
        Task<List<ItemsForBillDTO>> GetAnonymousItemsForBillAsync(List<int> itemsIds, int v2);
    }
}
