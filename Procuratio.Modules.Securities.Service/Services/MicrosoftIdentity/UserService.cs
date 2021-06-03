using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Exceptions;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Services.MicrosoftIdentity
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, 
            IConfiguration configuration, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<IReadOnlyList<UserDTO>> BrowseAsync()
        {
            IReadOnlyList<User> users = await _userRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<UserDTO>>(users);
        }

        public async Task AddAsync(AddUserDTO addDTO)
        {
            User user = new() 
            { 
                UserName = addDTO.UserName, 
                NormalizedUserName = addDTO.UserName,
                Password = addDTO.Password, 
                UserSurname =  addDTO.UserSurname,
                NormalizedUserSurname = addDTO.UserSurname,
                UserStateID = 1 // Cambiar esto (falta agregar la seed)
            };

            await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            User table = await GetUserAsync(id);
            await _userRepository.DeleteAsync(table);
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            User table = await GetUserAsync(id);

            return _mapper.Map<UserDTO>(table);
        }

        public async Task UpdateAsync(UpdateUserDTO updateDTO)
        {
            User user = await GetUserAsync(updateDTO.Id);

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

        public async Task<ActionResult<AuthenticationResponseDTO>> Login(UserCredentialsDTO userCredentialsDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(userCredentialsDTO.UserName, userCredentialsDTO.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(userCredentialsDTO);
            }

            return null;
        }

        private async Task<AuthenticationResponseDTO> BuildToken(UserCredentialsDTO credentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("restaurantid", credentials.RestaurantID.ToString()),
                new Claim(ClaimTypes.Name, credentials.UserName.ToString())
            };

            User user = await _userManager.FindByIdAsync(credentials.Id.ToString());
            IList<Claim> claimsDB = await _userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llavejwt"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddDays(1);

            var token = new JwtSecurityToken(
                issuer: null, 
                audience: null, 
                claims: claims,
                expires: expiracion, 
                signingCredentials: credential);

            return new AuthenticationResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiracion
            };
        }
    }
}
