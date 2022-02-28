using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Procuratio.Modules.Restaurant.Shared;
using Procuratio.Modules.Securities.DataAccess.EF.JWT;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Exceptions;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces;
using Procuratio.Modules.Security.Service.DTOs;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs.Profile;
using Procuratio.Modules.Security.Service.Exceptions;
using Procuratio.Shared.Infrastructure.Exceptions;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using Procuratio.Shared.ProcuratioFramework.JWT;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Services.MicrosoftIdentity
{
    internal sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IValidateChangeStateUser _validateChangeStateUser;
        private readonly IBranchModuleAPI _branchModuleAPI;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, IValidateChangeStateUser validateChangeStateUser, 
            IBranchModuleAPI branchModuleAPI)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _validateChangeStateUser = validateChangeStateUser;
            _branchModuleAPI = branchModuleAPI;
        }

        public async Task<IReadOnlyList<UserForListDTO>> BrowseAsync()
        {
            IReadOnlyList<User> users = await _userRepository.BrowseAsync();
            return _mapper.Map<IReadOnlyList<UserForListDTO>>(users);
        }

        public async Task AddAsync(UserFromFormDTO addDTO)
        {
            User user = new();

            user = _mapper.Map(addDTO, user);

            user.TwoFactorEnabled = false;

            _validateChangeStateUser.SetFromWithoutStateToActive(user);

            await _userRepository.AddAsync(user);

            User newUser = await _userRepository.GetByUserNameAsync(user.UserName);

            await _userRepository.SetRole(newUser, addDTO.Role);
        }

        public async Task DeleteAsync(int id)
        {
            User user = await GetUserAsync(id);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            User user = await GetUserAsync(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateAsync(UserFromFormDTO updateDTO, int Id)
        {
            User user = await GetUserAsync(Id);

            user = _mapper.Map(updateDTO, user);

            await _userRepository.RemoveRoles(user);
            await _userRepository.SetRole(user, updateDTO.Role);

            await _userRepository.UpdateAsync(user);
        }

        private async Task<User> GetUserAsync(int id)
        {
            User user = await _userRepository.GetAsync(id);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public async Task<UserCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            UserCreationFormInitializerDTO userCreationFormInitializerDTO = new();
            
            List<Role> roles = await _userRepository.GetRolesAsync();

            roles.ForEach(x => userCreationFormInitializerDTO.Roles.Add(new SelectListItemDTO { Id = x.Name, Description = x.Name }));

            return userCreationFormInitializerDTO;
        }

        public async Task<UserEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            User user = await _userRepository.GetEntityEditionFormInitializerAsync(id);

            List<Role> roles = await _userRepository.GetRolesAsync();
            IList<string> userRoles = await _userRepository.GetRolesByUserAsync(user);

            string userRole = string.Empty;

            foreach (string item in userRoles)
            {
                userRole = item;
                break;
            }

            return _mapper.Map<UserEditionFormInitializerDTO>(user, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    roles.ForEach(x => dest.Roles.Items.Add(new SelectListItemDTO { Id = x.Name, Description= x.Name }));
                    dest.Roles.SelectedOptionId = userRole;
                });
            });
        }

        public async Task<ProfileEditionFormInitializerDTO> GetProfileEditionFormInitializerAsync(int userId)
        {
            User user = await _userRepository.GetAsync(userId);

            IList<string> roles = await _userRepository.GetRolesByUserAsync(user);

            ProfileEditionFormInitializerDTO profileEditionFormInitializerDTO = new();

            return _mapper.Map<ProfileEditionFormInitializerDTO>(user, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.Roles = roles;
                });
            });
        }

        public async Task UpdateProfileAsync(ProfileFromFormDTO profileFromFormDTO, int userId)
        {
            User user = await _userRepository.GetAsync(userId);

            user = _mapper.Map(profileFromFormDTO, user);

            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> UpdatePassword(ChangeUserPasswordDTO changeUserPasswordDTO, int userId)
        {
            User user = await _userRepository.GetAsync(userId);

            SignInResult signInresult = await _userRepository.AuthAsync(user, changeUserPasswordDTO.CurrentPassword);

            if (!signInresult.Succeeded) { throw new InvalidPasswordException(); }

            IdentityResult identityResult = await _userRepository.UpdatePassword(user, changeUserPasswordDTO.Password);

            return identityResult.Succeeded;
        }

        public async Task<AuthenticationResponseDTO> AuthAsync(UserCredentialsDTO userCredentialsDTO)
        {
            User user = await _userRepository.GetByUserNameIgnoringQueryFiltersAsync(userCredentialsDTO.UserName);

            if (user is null) return null;

            SignInResult signInresult = await _userRepository.AuthAsync(user, userCredentialsDTO.Password);

            if (signInresult.Succeeded) { return await BuildToken(userCredentialsDTO, user); }

            return null;
        }

        public async Task<AuthenticationResponseDTO> AdminAuthAsync(AdminCredentialsDTO adminCredentialsDTO)
        {
            bool existBranchId = await _branchModuleAPI.ExistBranchId(adminCredentialsDTO.BranchId);

            if (!existBranchId) { throw new BranchIdNotFoundException(); }

            User user = await _userRepository.GetByUserNameIgnoringQueryFiltersAsync(adminCredentialsDTO.UserName);

            if (user is null) return null;

            SignInResult signInresult = await _userRepository.AuthAsync(user, adminCredentialsDTO.Password);

            if (signInresult.Succeeded) { return await BuildAdminToken(adminCredentialsDTO, user); }

            return null;
        }

        private async Task<AuthenticationResponseDTO> BuildToken(UserCredentialsDTO credentials, User user)
        {
            List<Claim> claims = new()
            {
                new Claim(JWTClaimNames.BranchId, user.BranchId.ToString()),
                new Claim(JWTClaimNames.UserId, user.Id.ToString()),
                new Claim(JWTClaimNames.UserFullName, $"{user.Name} {user.Surname}"),
            };

            IList<Claim> claimsDB = await _userRepository.GetClaimsAsync(user);
            claims.AddRange(claimsDB);

            IList<string> roles = await _userRepository.GetRolesByUserAsync(user);

            if (roles.Contains("Administrador")) { throw new InvalidAuthForUserAdminException(); }
            if (user.BranchId <= 0) { throw new BranchIdNotFoundException(); }

            foreach (string role in roles)
            {
                claims.Add(new Claim(JWTClaimNames.Role, role));
            }

            JsonWebToken options = _configuration.GetSection(nameof(JsonWebToken)).Get<JsonWebToken>();

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(options.Key));
            SigningCredentials credential = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credential);

            return new AuthenticationResponseDTO() { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        private async Task<AuthenticationResponseDTO> BuildAdminToken(AdminCredentialsDTO credentials, User user)
        {
            List<Claim> claims = new()
            {
                new Claim(JWTClaimNames.BranchId, credentials.BranchId.ToString()),
                new Claim(JWTClaimNames.UserId, user.Id.ToString()),
                new Claim(JWTClaimNames.UserFullName, $"{user.Name} {user.Surname}"),
            };

            IList<Claim> claimsDB = await _userRepository.GetClaimsAsync(user);
            claims.AddRange(claimsDB);

            IList<string> roles = await _userRepository.GetRolesByUserAsync(user);

            if (!roles.Contains("Administrador")) { throw new AdminRoleRequiredException(); }

            foreach (string role in roles)
            {
                claims.Add(new Claim(JWTClaimNames.Role, role));
            }

            JsonWebToken options = _configuration.GetSection(nameof(JsonWebToken)).Get<JsonWebToken>();

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(options.Key));
            SigningCredentials credential = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credential);

            return new AuthenticationResponseDTO() { Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
