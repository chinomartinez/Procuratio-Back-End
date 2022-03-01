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
        Task<Microsoft.AspNetCore.Identity.SignInResult> AuthAsync(User user, string password);

        Task<User> GetByUserNameIgnoringQueryFiltersAsync(string userName);

        Task<IList<Claim>> GetClaimsAsync(User user);

        Task<IList<string>> GetRolesByUserAsync(User user);

        Task<List<Role>> GetRolesAsync();

        Task SetRole(User user, string role);

        Task<User> GetByUserNameAsync(string name);

        Task<IdentityResult> UpdatePassword(User user, string newPassword);

        Task RemoveRoles(User user);
    }
}
