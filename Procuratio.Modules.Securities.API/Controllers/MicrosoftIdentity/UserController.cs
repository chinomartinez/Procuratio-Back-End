using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.API.Controllers.Base;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.API.Controllers.MicrosoftIdentity
{
    internal class UserController : BaseController, IBaseControllerOperations<UserDTO, UpdateUserDTO, AddUserDTO, int>
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
        public async Task<ActionResult<IReadOnlyList<UserDTO>>> BrowseAsync() => Ok(await _userService.BrowseAsync());

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetAsync(int id)
        {
            ActionResult<UserDTO> dinerInDetailsDTO = await _userService.GetAsync(id);

            if (dinerInDetailsDTO is null)
            {
                return NotFound();
            }

            return Ok(dinerInDetailsDTO);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] UpdateUserDTO updateDTO)
        {
            await _userService.UpdateAsync(updateDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponseDTO>> Login([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            ActionResult<AuthenticationResponseDTO> authenticationResponseDTO = await _userService.Login(userCredentialsDTO);

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
