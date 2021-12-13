using Microsoft.AspNetCore.Identity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity
{
    public interface IUserRepository : IBaseRepositoryOperations<User, int>
    {
        Task<SignInResult> AuthAsync(User user, string password);

        Task<User> GetByUserNameIgnoringQueryFilters(string userName);

        Task<IList<Claim>> GetClaimsAsync(User user);

        Task<IList<string>> GetRolesAsync(User user);
    }
}
