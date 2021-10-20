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
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ItemCategoryForListDTO>>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<ItemCategoryDTO>> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<ItemCategoryCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<ItemCategoryEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromBody] ItemCategoryFromFormDTO updateDTO, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
