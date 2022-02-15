using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.API.Controllers.Base;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs.Profile;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using Procuratio.Shared.Infrastructure.Controllers;
using Procuratio.Shared.ProcuratioFramework.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.API.Controllers.MicrosoftIdentity
{
    internal class UserController : BaseController, IBaseControllerOperations<UserDTO, UserForListDTO, UserFromFormDTO, UserCreationFormInitializerDTO, UserEditionFormInitializerDTO, int>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] UserFromFormDTO createDTO)
        {
            await _userService.AddAsync(createDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserForListDTO>>> BrowseAsync() => Ok(await _userService.BrowseAsync());

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

        [HttpPut(BasicStringsForControllers.IntParameter)]
        public async Task<ActionResult> UpdateAsync([FromBody] UserFromFormDTO updateDTO, int id)
        {
            await _userService.UpdateAsync(updateDTO, id);
            return NoContent();
        }

        [HttpGet(BasicStringsForControllers.EntityCreationFormInitializer)]
        public async Task<ActionResult<UserCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync()
        {
            UserCreationFormInitializerDTO userCreationFormInitializerDTO = await _userService.GetEntityCreationFormInitializerAsync();

            if (JWTClaims.GetRole(HttpContext) != "Administrador")
            {
                userCreationFormInitializerDTO.Roles = userCreationFormInitializerDTO.Roles.Where(x => x.Id != "Gerente").ToList();
            }

            return userCreationFormInitializerDTO;
        }

        [HttpGet(BasicStringsForControllers.EntityEditionFormInitializer)]
        public async Task<ActionResult<UserEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(int id)
        {
            return Ok(await _userService.GetEntityEditionFormInitializerAsync(id));
        }

        [HttpGet("profile-edition-form-initializer")]
        public async Task<ActionResult<ProfileEditionFormInitializerDTO>> GetProfileEditionFormInitializerAsync()
        {
            return Ok(await _userService.GetProfileEditionFormInitializerAsync(Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JWTClaimNames.UserId).Value)));
        }

        [HttpPut("profile")]
        public async Task<ActionResult> UpdateProfileAsync([FromForm] ProfileFromFormDTO profileFromFormDTO)
        {
            await _userService.UpdateProfileAsync(profileFromFormDTO, Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JWTClaimNames.UserId).Value));
            return NoContent();
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponseDTO>> AuthAsync([FromBody] UserCredentialsDTO userCredentialsDTO)
        {
            AuthenticationResponseDTO authenticationResponseDTO = await _userService.AuthAsync(userCredentialsDTO);

            if (authenticationResponseDTO is not null)
            {
                return Ok(authenticationResponseDTO);
            }
            else
            {
                return BadRequest("Usuario y/o contraseña invalido");
            }
        }

        [HttpPost("admin-auth")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponseDTO>> AdminAuthAsync([FromBody] AdminCredentialsDTO adminCredentialsDTO)
        {
            AuthenticationResponseDTO authenticationResponseDTO = await _userService.AdminAuthAsync(adminCredentialsDTO);

            if (authenticationResponseDTO is not null)
            {
                return Ok(authenticationResponseDTO);
            }
            else
            {
                return BadRequest("Usuario y/o contraseña invalido");
            }
        }
    }
}
