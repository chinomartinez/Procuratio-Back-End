using Microsoft.AspNetCore.Identity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using System.Collections.Generic;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class User : IdentityUser<int>
    {
        public Restaurant Restaurant { get; set; }
        public int RestaurantID { get; set; }

        public string UserSurname { get; set; }

        public string NormalizedUserSurname { get; set; }

        public UserState UserState { get; set; }
        public short UserStateID { get; set; }

        public string Password { get; set; }
    }
}
