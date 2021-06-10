﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.Modules.Securities.Service.Exceptions;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IValidateChangeStateUser _validateChangeStateUser;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager,
            IConfiguration configuration, SignInManager<User> signInManager, IValidateChangeStateUser validateChangeStateUser)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _validateChangeStateUser = validateChangeStateUser;
        }

        public async Task<IReadOnlyList<UserDTO>> BrowseAsync()
        {
            IReadOnlyList<User> users = await _userRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<UserDTO>>(users);
        }

        public async Task AddAsync(AddUserDTO addDTO)
        {
            User user = new();

            user = _mapper.Map(addDTO, user);

            user.TwoFactorEnabled = false;

            _validateChangeStateUser.SetFromWithoutStateToActive(user);

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
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(userCredentialsDTO.UserName,
                userCredentialsDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(userCredentialsDTO);
            }

            return null;
        }

        private async Task<AuthenticationResponseDTO> BuildToken(UserCredentialsDTO credentials)
        {
            User user = await _userManager.FindByNameAsync(credentials.UserName);

            List<Claim> claims = new()
            {
                new Claim("restaurantid", user.BranchID.ToString()),
                new Claim("username", user.UserName)
            };

            IList<Claim> claimsDB = await _userManager.GetClaimsAsync(user);

            claims.AddRange(claimsDB);

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["JWTKey"]));
            SigningCredentials credential = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credential);

            return new AuthenticationResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
