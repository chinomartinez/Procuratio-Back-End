using Microsoft.AspNetCore.Identity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class UserXRole : IdentityUserRole<int>, IRestaurant
    {
        public int BranchId { get; set; }
    }
}
