using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    [Route(template: BasePath + "/dine-in")]
    internal class DineInController : BaseController, IBaseControllerOperations<DineInDTO, DineInForListDTO, DineInFromFormDTO, DineInCreationFormInitializerDTO, DineInEditionFormInitializerDTO, int>
    {
        private readonly IDineInService _dinerInService;

        public DineInController(IDineInService dinerInService)
        {
            _dinerInService = dinerInService;
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
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
        public async Task<ActionResult> AddAsync([FromForm] DineInFromFormDTO dineInCreationDTO)
        {
            await _dinerInService.AddAsync(dineInCreationDTO);
            return NoContent();
            //return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DineInForListDTO>>> BrowseAsync() => Ok(await _dinerInService.BrowseAsync());

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromForm] DineInFromFormDTO dineInUpdateDTO, int id)
        {
            await _dinerInService.UpdateAsync(dineInUpdateDTO, id);
            return NoContent();
        }

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _dinerInService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<DineInCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            return Ok(await _dinerInService.GetEntityCreationFormInitializerAsync());
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<DineInEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _dinerInService.GetEntityEditionFormInitializerAsync(id));
        }

        [HttpGet("in-progress")]
        public async Task<ActionResult<DineInInProgressDTO>> GetDineInInProgressAsync()
        {
            return Ok(await _dinerInService.GetDineInInProgressAsync());
        }
    }
}
