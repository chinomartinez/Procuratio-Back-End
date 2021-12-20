using Procuratio.Modules.Menu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Shared
{
    public interface IItemModuleAPI
    {
        Task<List<MenuForOrderDetailDTO>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn);

        Task<List<ItemsForOrderDetailInKitchenDTO>> GetItemsForKitchenAsync(List<int> itemIds);
    }
}
