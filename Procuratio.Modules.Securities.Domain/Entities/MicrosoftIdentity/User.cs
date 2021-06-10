using Microsoft.AspNetCore.Identity;
using Procuratio.Modules.Securities.Domain.Entities.State;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class User : IdentityUser<int>
    {
        public int BranchID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public UserState UserState { get; set; }
        public short UserStateID { get; set; }

        public string Password { get; set; }
    }
}
