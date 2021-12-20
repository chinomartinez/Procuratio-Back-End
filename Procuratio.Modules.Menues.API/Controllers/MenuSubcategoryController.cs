using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.Modules.Menues.API.Controllers.Base;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.API.Controllers
{
    [Route(template: BasePath + "/menu-subcategory")]
    internal class MenuSubcategoryController : BaseController, IBaseControllerOperations<MenuSubcategoryDTO, MenuSubcategoryForListDTO, MenuSubcategoryFromFormDTO, MenuSubcategoryCreationFormInitializerDTO, MenuSubcategoryEditionFormInitializerDTO, int>
    {
        private readonly IMenuSubcategoryService _menuSubcategoryService;

        public MenuSubcategoryController(IMenuSubcategoryService menuSubcategoryService)
        {
            _menuSubcategoryService = menuSubcategoryService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] MenuSubcategoryFromFormDTO addDTO)
        {
            await _menuSubcategoryService.AddAsync(addDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MenuSubcategoryForListDTO>>> BrowseAsync() => Ok(await _menuSubcategoryService.BrowseAsync());

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _menuSubcategoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<MenuSubcategoryDTO>> GetAsync(int id)
        {
            ActionResult<MenuSubcategoryDTO> menuSubcategoryDTO = await _menuSubcategoryService.GetAsync(id);

            if (menuSubcategoryDTO is null)
            {
                return NotFound();
            }

            return Ok(menuSubcategoryDTO);
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<MenuSubcategoryCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            return Ok(await _menuSubcategoryService.GetEntityCreationFormInitializerAsync());
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<MenuSubcategoryEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _menuSubcategoryService.GetEntityEditionFormInitializerAsync(id));
        }

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromBody] MenuSubcategoryFromFormDTO updateDTO, int id)
        {
            await _menuSubcategoryService.UpdateAsync(updateDTO, id);
            return NoContent();
        }
    }
}
