using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.API.Controllers.Base;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.API.Controllers
{
    internal class ItemController : BaseController, IBaseControllerOperations<ItemDTO, ItemForListDTO, ItemFromFormDTO, ItemCreationFormInitializerDTO, ItemEditionFormInitializerDTO, int>
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromForm] ItemFromFormDTO addDTO)
        {
            await _itemService.AddAsync(addDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ItemForListDTO>>> BrowseAsync() => Ok(await _itemService.BrowseAsync());

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _itemService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<ItemDTO>> GetAsync(int id)
        {
            ActionResult<ItemDTO> itemCategoryDTO = await _itemService.GetAsync(id);

            if (itemCategoryDTO is null)
            {
                return NotFound();
            }

            return Ok(itemCategoryDTO);
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<ItemCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            return Ok(await _itemService.GetEntityCreationFormInitializerAsync());
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<ItemEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _itemService.GetEntityEditionFormInitializerAsync(id));
        }

        [HttpPost(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromForm] ItemFromFormDTO updateDTO, int id)
        {
            await _itemService.UpdateAsync(updateDTO, id);
            return NoContent();
        }

        [HttpGet("menu-add-item-to-order")]
        public async Task<ActionResult<IReadOnlyList<MenuAddItemsToOrderVM>>> GetMenuAddItemsToOrderAsync([FromQuery] List<int> ids)
        {
            return Ok(await _itemService.GetMenuAddItemsToOrderAsync(ids));
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<ItemDTO>>> GetByIds([FromQuery] List<int> ids)
        {
            return Ok(await _itemService.GetByIds(ids));
        }
    }
}
