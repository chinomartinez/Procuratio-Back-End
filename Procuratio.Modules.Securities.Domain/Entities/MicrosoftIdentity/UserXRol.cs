using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class UserXRole : IdentityUserRole<int>
    {
        public int BranchID { get; set; }
    }
}
