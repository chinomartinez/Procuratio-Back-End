﻿using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity
{
    public interface IUserService : IBaseServiceOperations<UserDTO, UserForListDTO, UserFromFormDTO, UserCreationFormInitializerDTO, UserEditionFormInitializerDTO, int>
    {
        public Task<AuthenticationResponseDTO> AuthAsync(UserCredentialsDTO userCredentialsDTO);

        public Task CreateCreateUsersAndRolesAsync();
    }
}
