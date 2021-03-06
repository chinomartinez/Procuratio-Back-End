using Microsoft.AspNetCore.Identity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Security.Service.DTOs;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs.Profile;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity
{
    public interface IUserService : IBaseServiceOperations<UserDTO, UserForListDTO, UserFromFormDTO, UserCreationFormInitializerDTO, UserEditionFormInitializerDTO, int>
    {
        public Task<AuthenticationResponseDTO> AuthAsync(UserCredentialsDTO userCredentialsDTO);

        public Task<ProfileEditionFormInitializerDTO> GetProfileEditionFormInitializerAsync(int userId);

        public Task UpdateProfileAsync(ProfileFromFormDTO profileFromFormDTO, int userId);

        Task<AuthenticationResponseDTO> AdminAuthAsync(AdminCredentialsDTO adminCredentialsDTO);

        Task<bool> UpdatePassword(ChangeUserPasswordDTO changeUserPasswordDTO, int userId);
    }
}
