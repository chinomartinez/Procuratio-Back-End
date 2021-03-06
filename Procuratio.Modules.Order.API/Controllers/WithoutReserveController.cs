using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.API.Controllers.Base;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using Procuratio.Shared.ProcuratioFramework.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.API.Controllers
{
    [Route(template: BasePath + "/without-reserve")]
    internal class WithoutReserveController : BaseController, IBaseControllerOperations<WithoutReserveDTO, WithoutReserveForListDTO, WithoutReserveFromFormDTO, WithoutReserveCreationFormInitializerDTO, WithoutReserveEditionFormInitializerDTO, int>
    {
        private readonly IWithoutReserveService _withoutReserveService;

        public WithoutReserveController(IWithoutReserveService withoutReserveService)
        {
            _withoutReserveService = withoutReserveService;
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<WithoutReserveDTO>> GetAsync(int id)
        {
            ActionResult<WithoutReserveDTO> withoutReserveDetailsDTO = await _withoutReserveService.GetAsync(id);

            if (withoutReserveDetailsDTO is null)
            {
                return NotFound();
            }

            return Ok(withoutReserveDetailsDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] WithoutReserveFromFormDTO withoutReserveCreationDTO)
        { 
            withoutReserveCreationDTO.UserId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JWTClaimNames.UserId).Value);
            await _withoutReserveService.AddAsync(withoutReserveCreationDTO);
            return NoContent();
            //return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<WithoutReserveForListDTO>>> BrowseAsync() => Ok(await _withoutReserveService.BrowseAsync());

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromBody] WithoutReserveFromFormDTO withoutReserveUpdateDTO, int id)
        {
            await _withoutReserveService.UpdateAsync(withoutReserveUpdateDTO, id);
            return NoContent();
        }

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _withoutReserveService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<WithoutReserveCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync() => Ok(await _withoutReserveService.GetEntityCreationFormInitializerAsync());

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<WithoutReserveEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id) => Ok(await _withoutReserveService.GetEntityEditionFormInitializerAsync(id));

        [HttpPost("online-menu-auth")]
        [AllowAnonymous]
        public async Task<ActionResult<CutomerAuthenticationResponseDTO>> OnlineMenuAuth([FromBody] CustomerCredentialsDTO customerCredentialsDTO)
        {
            CutomerAuthenticationResponseDTO cutomerAuthenticationResponseDTO = await _withoutReserveService.OnlineMenuAuth(customerCredentialsDTO);

            if (cutomerAuthenticationResponseDTO is not null)
            {
                return Ok(cutomerAuthenticationResponseDTO);
            }
            else
            {
                return BadRequest("Inicio de sesión invalido");
            }
        }
    }
}
