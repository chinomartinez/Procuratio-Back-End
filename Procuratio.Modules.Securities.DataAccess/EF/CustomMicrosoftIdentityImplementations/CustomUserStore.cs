using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.DataAccess;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations
{
    internal class CustomUserStore : UserStore<User, Role, SecurityDbContext, int, UserClaim, UserXRole, UserLogin, 
        UserToken, RoleClaim>
    {
        public CustomUserStore(SecurityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        public async Task<User> FindByNameAsyncIgnoringQueryFilters(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            
            return await Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName, cancellationToken);
        }
    }
}
