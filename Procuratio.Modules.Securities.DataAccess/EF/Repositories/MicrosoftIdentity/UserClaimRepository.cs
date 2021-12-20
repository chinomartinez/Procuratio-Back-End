using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity
{
    internal class UserClaimRepository : IUserClaimRepository
    {
        private readonly SecurityDbContext securitiesDbContext;

        public UserClaimRepository(SecurityDbContext securitiesDbContext)
        {
            this.securitiesDbContext = securitiesDbContext;
        }

        public async Task AddAsync(UserClaim toAdd)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<UserClaim>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(UserClaim entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<UserClaim>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserClaim> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserClaim>> GetByIdsAsync(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserClaim> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(UserClaim toUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
