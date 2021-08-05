using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    internal class DineInController : BaseController, IBaseControllerOperations<DineInDTO, DineInListDTO, DineInFromFormDTO, DineInCreationFormInitializerDTO, DineInEditionFormInitializerDTO, int>
    {
        private readonly IDineInService _dinerInService;

        public DineInController(IDineInService dinerInService)
        {
            _dinerInService = dinerInService;
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<DineInDTO>> GetAsync(int ID)
        {
            ActionResult<DineInDTO> dinerInDetailsDTO = await _dinerInService.GetAsync(ID);

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

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int ID)
        {
            await _dinerInService.DeleteAsync(ID);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<DineInCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<DineInEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}
