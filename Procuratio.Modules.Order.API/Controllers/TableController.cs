using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    internal class TableController : BaseController, IBaseControllerOperations<TableDTO, TableForListDTO, TableFromFormDTO, TableCreationFormInitializerDTO, TableEditionFormInitializerDTO, int>
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromForm] TableFromFormDTO createDTO)
        {
            await _tableService.AddAsync(createDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TableForListDTO>>> BrowseAsync() => Ok(await _tableService.BrowseAsync());

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _tableService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<TableDTO>> GetAsync(int id)
        {
            ActionResult<TableDTO> tableDTO = await _tableService.GetAsync(id);

            if (tableDTO is null)
            {
                return NotFound();
            }

            return Ok(tableDTO);
        }

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromForm] TableFromFormDTO updateDTO, int id)
        {
            await _tableService.UpdateAsync(updateDTO, id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<TableCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            return Ok(await _tableService.GetEntityCreationFormInitializerAsync());
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<TableEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _tableService.GetEntityEditionFormInitializerAsync(id));
        }
    }
}
