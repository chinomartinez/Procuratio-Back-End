using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    internal class DineInController : BaseController, IBaseControllerOperations<DineInDTO, DineInListDTO, DineInFromFormDTO, int>
    {
        private readonly IDineInService _dinerInService;

        public DineInController(IDineInService dinerInService)
        {
            _dinerInService = dinerInService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DineInDTO>> GetAsync(int id)
        {
            ActionResult<DineInDTO> dinerInDetailsDTO = await _dinerInService.GetAsync(id);

            if (dinerInDetailsDTO is null)
            {
                return NotFound();
            }

            return Ok(dinerInDetailsDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] DineInFromFormDTO dineInCreationDTO)
        {
            await _dinerInService.AddAsync(dineInCreationDTO);
            return NoContent();
            //return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DineInListDTO>>> BrowseAsync() => Ok(await _dinerInService.BrowseAsync());

        [HttpPut]
        public async Task UpdateAsync([FromBody] DineInFromFormDTO dineInUpdateDTO, int ID)
        {
            await _dinerInService.UpdateAsync(dineInUpdateDTO, ID);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _dinerInService.DeleteAsync(id);
            return NoContent();
        }
    }
}
