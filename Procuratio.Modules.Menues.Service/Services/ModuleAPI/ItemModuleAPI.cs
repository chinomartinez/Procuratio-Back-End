using Procuratio.Modules.Menu.Shared;
using Procuratio.Modules.Menu.Shared.DTO;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Services.ModuleAPI
{
    internal sealed class ItemModuleAPI : IItemModuleAPI
    {
        private readonly IItemService _itemService;

        public ItemModuleAPI(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<List<MenuForOrderDetailDTO>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn)
        {
            return await _itemService.GetMenuForOrderDetailAsync(itemIds, dineIn);
        }

        public async Task<List<ItemsForOrderDetailInKitchenDTO>> GetItemsForKitchenAsync(List<int> itemIds)
        {
            return await _itemService.GetItemsForKitchenAsync(itemIds);
        }

        public async Task<List<ItemsForBillDTO>> GetItemsFoBillAsync(List<int> itemIds, bool dineIn)
        {
            return await _itemService.GetItemsFoBillAsync(itemIds, dineIn);
        }
    }
}
