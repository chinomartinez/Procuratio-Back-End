using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class User : IdentityUser<int>
    {
        public Restaruant Restaruant { get; set; }

        public int RestaurantID { get; set; }
    }
}
