using Microsoft.AspNetCore.Identity;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public int BranchID { get; set; }
    }
}
