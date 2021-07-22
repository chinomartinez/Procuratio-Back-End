using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    internal class TableController : BaseController, IBaseControllerOperations<TableDTO, UpdateTableDTO, AddTableDTO, int>
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] AddTableDTO createDTO)
        {
            await _tableService.AddAsync(createDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TableDTO>>> BrowseAsync() => Ok(await _tableService.BrowseAsync());

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _tableService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TableDTO>> GetAsync(int id)
        {
            ActionResult<TableDTO> tableDTO = await _tableService.GetAsync(id);

            if (tableDTO is null)
            {
                return NotFound();
            }

            return Ok(tableDTO);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateTableDTO updateDTO)
        {
            await _tableService.UpdateAsync(updateDTO);
        }

        [HttpGet("last-table-number")]
        public async Task<ActionResult<int>> GetLastTableNumberAsync()
        {
            // TODO: Terminar esto y ver de cambiar de statename a name...

            return Ok(22);
        }
    }
}
