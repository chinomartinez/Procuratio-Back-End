using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity
{
    internal class UserRepository : IUserRepository
    {
        private readonly SecurityDbContext _securitiesDbContext;
        private readonly DbSet<User> _user;
        private readonly CustomUserManager _userManager;
        private readonly CustomSignInManager _signInManager;

        public UserRepository(SecurityDbContext securitiesDbContext, CustomUserManager userManager, CustomSignInManager signInManager)
        {
            _securitiesDbContext = securitiesDbContext;
            _user = _securitiesDbContext.Users;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IReadOnlyList<User>> BrowseAsync() => await _user.AsNoTracking().ToListAsync();

        public async Task AddAsync(User toAdd) => await _userManager.CreateAsync(toAdd, toAdd.Password);

        public async Task DeleteAsync(User entity) => await _userManager.DeleteAsync(entity);

        public async Task<User> GetAsync(int id) => await _userManager.FindByIdAsync(id.ToString());

        public async Task UpdateAsync(User toUpdate) => await _userManager.UpdateAsync(toUpdate);

        public async Task<SignInResult> AuthAsync(User user, string password) => await _signInManager.PasswordSignInAsync(user, password, false, false);

        public async Task<User> GetEntityEditionFormInitializerAsync(int id)
        {
            return await _user.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetByIdsAsync(List<int> ids) => await _user.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<User> GetByUserNameIgnoringQueryFiltersAsync(string userName) => await _userManager.FindByNameIgnoringQueryFiltersAsync(userName);

        public async Task<IList<Claim>> GetClaimsAsync(User user) => await _userManager.GetClaimsAsync(user);

        public async Task<IList<string>> GetRolesAsync(User user) => await _userManager.GetRolesAsync(user);
    }
}
