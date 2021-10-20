using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.API.Controllers.Base;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        public Task<ActionResult> AddAsync([FromBody] ItemFromFormDTO addDTO)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<IReadOnlyList<ItemForListDTO>>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public Task<ActionResult> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public Task<ActionResult<ItemDTO>> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public Task<ActionResult<ItemCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public Task<ActionResult<ItemEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public Task<ActionResult> UpdateAsync([FromBody] ItemFromFormDTO updateDTO, int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("menu")]
        public async Task<ActionResult<IReadOnlyList<MenuDTO>>> GetMenuAsync()
        {
            return Ok(await _itemService.GetMenuAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<ItemDTO>>> GetByIds([FromQuery] List<int> ids)
        {
            return Ok(await _itemService.GetByIds(ids));
        }
    }
}
