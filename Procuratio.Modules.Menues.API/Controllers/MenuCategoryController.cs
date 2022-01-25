using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menues.API.Controllers.Base;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.API.Controllers
{
    [Route(template: BasePath + "/menu-category")]
    internal class MenuCategoryController : BaseController, IBaseControllerOperations<MenuCategoryDTO, MenuCategoryForListDTO, MenuCategoryFromFormDTO, MenuCategoryCreationFormInitializerDTO, MenuCategoryEditionFormInitializerDTO, int>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public MenuCategoryController(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] MenuCategoryFromFormDTO addDTO)
        {
            await _menuCategoryService.AddAsync(addDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MenuCategoryForListDTO>>> BrowseAsync() => Ok(await _menuCategoryService.BrowseAsync());

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _menuCategoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<MenuCategoryDTO>> GetAsync(int id)
        {
            ActionResult<MenuCategoryDTO> menuCategoryDTO = await _menuCategoryService.GetAsync(id);

            if (menuCategoryDTO is null)
            {
                return NotFound();
            }

            return Ok(menuCategoryDTO);
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<MenuCategoryCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            return Ok(await _menuCategoryService.GetEntityCreationFormInitializerAsync());
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<MenuCategoryEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _menuCategoryService.GetEntityEditionFormInitializerAsync(id));
        }

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromBody] MenuCategoryFromFormDTO updateDTO, int id)
        {
            await _menuCategoryService.UpdateAsync(updateDTO, id);
            return NoContent();
        }

        [HttpGet("menu")]
        public async Task<ActionResult<IReadOnlyList<MenuDTO>>> GetMenuAsync()
        {
            return Ok(await _menuCategoryService.GetMenuAsync());
        }

        [HttpPost("menu")]
        public async Task<ActionResult> UpdateMenuAsync([FromBody] List<MenuDTO> menuDTOs)
        {
            await _menuCategoryService.UpdateMenuAsync(menuDTOs);
            return NoContent();
        }

        [HttpGet("dine-in-online-menu/{branchId:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<MenuDTO>>> GetDineInOnlineMenuAsync(int branchId)
        {
            return Ok(await _menuCategoryService.GetDineInOnlineMenuAsync(branchId));
        }
    }
}
