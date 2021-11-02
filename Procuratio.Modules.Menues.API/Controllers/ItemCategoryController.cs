using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Menu.Service.DTOs.ItemCategoryDTOs;
using Procuratio.Modules.Menues.API.Controllers.Base;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.API.Controllers
{
    [Route(template: BasePath + "/item-category")]
    internal class ItemCategoryController : BaseController, IBaseControllerOperations<ItemCategoryDTO, ItemCategoryForListDTO, ItemCategoryFromFormDTO, ItemCategoryCreationFormInitializerDTO, ItemCategoryEditionFormInitializerDTO, int>
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] ItemCategoryFromFormDTO addDTO)
        {
            await _itemCategoryService.AddAsync(addDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ItemCategoryForListDTO>>> BrowseAsync() => Ok(await _itemCategoryService.BrowseAsync());

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _itemCategoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<ItemCategoryDTO>> GetAsync(int id)
        {
            ActionResult<ItemCategoryDTO> itemCategoryDTO = await _itemCategoryService.GetAsync(id);

            if (itemCategoryDTO is null)
            {
                return NotFound();
            }

            return Ok(itemCategoryDTO);
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<ItemCategoryCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            return Ok(await _itemCategoryService.GetEntityCreationFormInitializerAsync());
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<ItemCategoryEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _itemCategoryService.GetEntityEditionFormInitializerAsync(id));
        }

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromBody] ItemCategoryFromFormDTO updateDTO, int id)
        {
            await _itemCategoryService.UpdateAsync(updateDTO, id);
            return NoContent();
        }
    }
}
