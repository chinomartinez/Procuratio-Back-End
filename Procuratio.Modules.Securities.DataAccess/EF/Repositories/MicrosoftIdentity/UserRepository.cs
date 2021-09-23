﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity
{
    internal class UserRepository : IUserRepository
    {
        private readonly SecurityDbContext _securitiesDbContext;
        private readonly DbSet<User> _user;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(SecurityDbContext securitiesDbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _securitiesDbContext = securitiesDbContext;
            _user = _securitiesDbContext.Users;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IReadOnlyList<User>> BrowseAsync()
        {
            return await _user.Where(x => x.BranchID == TGRID.BranchId).AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(User toAdd)
        {
            toAdd.BranchID = TGRID.BranchId;

            await _userManager.CreateAsync(toAdd, toAdd.Password);
        }

        public async Task DeleteAsync(User entity)
        {
            await Task.FromResult(_user.Remove(entity));
        }

        public async Task<User> GetAsync(int id)
        {
            return await _user.SingleOrDefaultAsync(x => x.Id == id && TGRID.BranchId == x.BranchID);
        }

        public async Task UpdateAsync(User toUpdate)
        {
            await _userManager.UpdateAsync(toUpdate);
        }

        public async Task<SignInResult> Loginasync(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
        }

        public Task<User> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<User>> GetByIdsAsync(List<int> ids) => await _user.Where(x => TGRID.BranchId == x.BranchID && ids.Contains(x.Id)).ToListAsync();
    }
}
