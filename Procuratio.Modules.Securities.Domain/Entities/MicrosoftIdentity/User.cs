using Microsoft.AspNetCore.Identity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class User : IdentityUser<int>, ITenant
    {
        public int BranchId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public UserState UserState { get; set; }
        public short UserStateId { get; set; }

        public string Password { get; set; }

        public string ProfilePicture { get; set; }
    }
}
