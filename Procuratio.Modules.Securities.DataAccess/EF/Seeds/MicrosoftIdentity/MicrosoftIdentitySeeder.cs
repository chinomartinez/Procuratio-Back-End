using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.DataAccess.EF.Seeds.MicrosoftIdentity
{
    internal class MicrosoftIdentitySeeder
    {
        internal static async Task EnsureSeedDataAsync(IServiceScope scope)
        {
            RoleManager<Role> roleManager = scope.ServiceProvider.GetService<RoleManager<Role>>();
            CustomUserManager customUserManager = scope.ServiceProvider.GetService<CustomUserManager>();

            string[] roles = new string[] { "Administrador", "Chef", "Mozo", "Gerente" };

            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role 
                    { 
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });
                }
            }

            string defaultUserName = "orion";

            if (await customUserManager.FindByNameIgnoringQueryFiltersAsync(defaultUserName) is null)
            {
                User user = new();
                user.UserName = defaultUserName;
                user.Name = "Tomas";
                user.Surname = "Gavagnin";
                user.UserStateId = (short)UserState.State.Active;
                user.Email = string.Empty;
                user.NormalizedEmail = string.Empty;
                user.PhoneNumber = "3534274171";
                user.ProfilePicture = string.Empty;

                IdentityResult checkUser = await customUserManager.CreateAsync(user, "admin123");

                if (checkUser.Succeeded)
                {
                    await customUserManager.AddToRoleAsync(user, roles[0]);
                }
            }
        }
    }
}
