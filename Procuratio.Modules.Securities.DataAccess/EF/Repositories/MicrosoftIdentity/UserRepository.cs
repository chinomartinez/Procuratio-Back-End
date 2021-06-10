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
        private readonly SecuritiesDbContext _securitiesDbContext;
        private readonly DbSet<User> _user;
        private readonly UserManager<User> _userManager;

        public UserRepository(SecuritiesDbContext securitiesDbContext, UserManager<User> userManager)
        {
            _securitiesDbContext = securitiesDbContext;
            _user = _securitiesDbContext.Users;
            _userManager = userManager;
        }

        public async Task<IReadOnlyList<User>> BrowseAsync()
        {
            return await _user.Where(x => x.BranchID == TGRID.BranchID).AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(User toCreate)
        {
            toCreate.BranchID = TGRID.BranchID;

            await _userManager.CreateAsync(toCreate, toCreate.Password);
        }

        public async Task DeleteAsync(User entity)
        {
            await Task.FromResult(_user.Remove(entity));
        }

        public async Task<User> GetAsync(int id)
        {
            return await _user.SingleOrDefaultAsync(x => x.Id == id && TGRID.BranchID == x.BranchID);
        }

        public async Task UpdateAsync(User toUpdate)
        {
            await _userManager.UpdateAsync(toUpdate);
        }
    }
}
