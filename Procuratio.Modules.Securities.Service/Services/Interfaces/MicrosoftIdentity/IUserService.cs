using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity
{
    public interface IUserService : IBaseServiceOperations<UserDTO, UpdateUserDTO, AddUserDTO, int>
    {
        public Task<AuthenticationResponseDTO> LoginAsync(UserCredentialsDTO userCredentialsDTO);
    }
}
