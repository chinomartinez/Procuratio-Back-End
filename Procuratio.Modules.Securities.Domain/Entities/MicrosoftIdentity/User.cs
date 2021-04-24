using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class User : IdentityUser<int>
    {
        public List<Restaruant> Restaruants { get; set; }
    }
}
