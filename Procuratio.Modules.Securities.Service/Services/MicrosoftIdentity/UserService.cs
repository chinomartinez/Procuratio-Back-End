using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Procuratio.Modules.Securities.DataAccess.EF.JWT;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Exceptions;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
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
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IValidateChangeStateUser _validateChangeStateUser;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager,
            IConfiguration configuration, IValidateChangeStateUser validateChangeStateUser, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _validateChangeStateUser = validateChangeStateUser;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IReadOnlyList<UserListDTO>> BrowseAsync()
        {
            IReadOnlyList<User> users = await _userRepository.BrowseAsync();
            throw new System.NotImplementedException();
            //return _mapper.Map<IReadOnlyList<UserListDTO>>(users);
        }

        public async Task AddAsync(UserFromFormDTO addDTO)
        {
            User user = new();

            user = _mapper.Map(addDTO, user);

            user.TwoFactorEnabled = false;

            _validateChangeStateUser.SetFromWithoutStateToActive(user);

            await _userRepository.AddAsync(user);
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
            throw new NotImplementedException();
        }

        public async Task<UserEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationResponseDTO> AuthAsync(UserCredentialsDTO userCredentialsDTO)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInresult = await _userRepository.AuthAsync(userCredentialsDTO.UserName, userCredentialsDTO.Password);

            if (signInresult.Succeeded) { return await BuildToken(userCredentialsDTO); }

            return null;
        }

        private async Task<AuthenticationResponseDTO> BuildToken(UserCredentialsDTO credentials)
        {
            User user = await _userManager.FindByNameAsync(credentials.UserName);

            List<Claim> claims = new()
            {
                new Claim(JWTClaimNames.BranchId, user.BranchId.ToString()),
                new Claim(JWTClaimNames.UserFullName, $"{user.Name} {user.Surname}"),
            };

            IList<Claim> claimsDB = await _userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

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
