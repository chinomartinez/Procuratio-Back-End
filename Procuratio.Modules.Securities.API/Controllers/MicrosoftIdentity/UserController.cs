using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.API.Controllers.Base;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.API.Controllers.MicrosoftIdentity
{
    internal class UserController : BaseController, IBaseControllerOperations<UserDTO, UserForListDTO, UpdateUserDTO, AddUserDTO, int>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> AddAsync([FromBody] AddUserDTO createDTO)
        {
            await _userService.AddAsync(createDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserForListDTO>>> BrowseAsync() => Ok(await _userService.BrowseAsync());

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:int}")]
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
        public async Task UpdateAsync([FromBody] UpdateUserDTO updateDTO)
        {
            await _userService.UpdateAsync(updateDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponseDTO>> LoginAsync([FromBody] UserCredentialsDTO userCredentialsDTO)
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
