using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.API.Controllers.Base;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.API.Controllers.MicrosoftIdentity
{
    internal class UserController : BaseController, IBaseControllerOperations<UserDTO, UserListDTO, UserFromFormDTO, UserCreationFormInitializerDTO, UserEditionFormInitializerDTO, int>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromForm] UserFromFormDTO createDTO)
        {
            await _userService.AddAsync(createDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserListDTO>>> BrowseAsync() => Ok(await _userService.BrowseAsync());

        [HttpDelete(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult<UserDTO>> GetAsync(int id)
        {
            UserDTO userDTO = await _userService.GetAsync(id);

            if (userDTO is null)
            {
                return NotFound();
            }

            return Ok(userDTO);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromForm] UserFromFormDTO updateDTO, int Id)
        {
            await _userService.UpdateAsync(updateDTO, Id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<UserCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<UserEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponseDTO>> LoginAsync([FromForm] UserCredentialsDTO userCredentialsDTO)
        {
            AuthenticationResponseDTO authenticationResponseDTO = await _userService.LoginAsync(userCredentialsDTO);

            if (authenticationResponseDTO is not null)
            {
                return Ok(authenticationResponseDTO);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }
    }
}
