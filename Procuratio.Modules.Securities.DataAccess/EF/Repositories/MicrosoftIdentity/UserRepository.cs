using Microsoft.AspNetCore.Identity;
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
            return await _user.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(User toAdd) => await _userManager.CreateAsync(toAdd, toAdd.Password);

        public async Task DeleteAsync(User entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _user.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(User toUpdate)
        {
            var sdsd = await _userManager.UpdateAsync(toUpdate);
            var sfdsd = "df";
        }

        public async Task<SignInResult> AuthAsync(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task<User> GetEntityEditionFormInitializerAsync(int id)
        {
            return await _user.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetByIdsAsync(List<int> ids) => await _user.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
