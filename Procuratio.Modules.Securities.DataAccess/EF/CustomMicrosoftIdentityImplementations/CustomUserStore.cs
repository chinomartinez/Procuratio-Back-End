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
        private readonly SecurityDbContext context;
        private readonly IdentityErrorDescriber describer;

        public CustomUserStore(SecurityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
            this.context = context;
            this.describer = describer;
        }

        public override Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            
            return Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName, cancellationToken);
        }
    }
}
