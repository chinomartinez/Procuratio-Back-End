using Microsoft.AspNetCore.Identity;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class UserToken : IdentityUserToken<int>
    {
        public int BranchID { get; set; }
    }
}
