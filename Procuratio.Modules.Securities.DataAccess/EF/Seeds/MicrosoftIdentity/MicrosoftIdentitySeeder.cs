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
        private static readonly string[] roles = new string[] { "Administrador", "Chef", "Mozo", "Gerente" };

        internal static async Task EnsureSeedDataAsync(IServiceScope scope)
        {
            RoleManager<Role> roleManager = scope.ServiceProvider.GetService<RoleManager<Role>>();
            CustomUserManager customUserManager = scope.ServiceProvider.GetService<CustomUserManager>();

            await CreateRoles(roleManager);
            await CreateAdminUser(customUserManager);
            await CreateDefaultUsers(customUserManager);
        }

        private static async Task CreateRoles(RoleManager<Role> roleManager)
        {
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
        }

        private static async Task CreateAdminUser(CustomUserManager customUserManager)
        {
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
                user.BranchId = -1;

                IdentityResult checkUser = await customUserManager.CreateAsync(user, "admin123");

                if (checkUser.Succeeded)
                {
                    await customUserManager.AddToRoleAsync(user, roles[0]);
                }
            }
        }

        private static async Task CreateDefaultUsers(CustomUserManager customUserManager)
        {
            string[] userNames = new string[] 
            {
                "chef1",
                "mozo1",
                "gerente1",
                "chef2",
                "mozo2",
                "gerente2",
                "chef3",
                "mozo3",
                "gerente3",
                "chef4",
                "mozo4",
                "gerente4",
            };

            string[] names = new string[]
            {
                "Benjamin",
                "Bruno",
                "Diego",
                "Federico",
                "Joaquin",
                "Leonardo",
                "Luciano",
                "Martin",
                "Matias",
                "Valentino",
                "Agustina",
                "Agustina"
            };

            string[] surnames = new string[]
            {
                "Gonzalez",
                "Rodriguez",
                "Gomez",
                "Fernandez",
                "Lopez",
                "Martinez",
                "Diaz",
                "Perez",
                "Sanchez",
                "Romero",
                "Garcia",
                "Sosa"
            };

            string[] passwords = new string[]
            {
                "chef1",
                "mozo1",
                "gerente1",
                "chef2",
                "mozo2",
                "gerente2",
                "chef3",
                "mozo3",
                "gerente3",
                "chef4",
                "mozo4",
                "gerente4",
            };

            int[] branchIds = new int[]
            {
                1,
                1,
                1,
                2,
                2,
                2,
                3,
                3,
                3,
                4,
                4,
                4
            };

            int auxRoleCount = 1;

            for (int i = 0; i < 12; i++)
            {
                if (await customUserManager.FindByNameIgnoringQueryFiltersAsync(userNames[i]) is null)
                {
                    User user = new();
                    user.UserName = userNames[i];
                    user.Name = names[i];
                    user.Surname = surnames[i];
                    user.UserStateId = (short)UserState.State.Active;
                    user.Email = string.Empty;
                    user.NormalizedEmail = string.Empty;
                    user.PhoneNumber = "3534274171";
                    user.ProfilePicture = string.Empty;
                    user.BranchId = branchIds[i];

                    IdentityResult checkUser = await customUserManager.CreateAsync(user, passwords[i]);

                    if (checkUser.Succeeded)
                    {
                        await customUserManager.AddToRoleAsync(user, roles[auxRoleCount]);
                    }
                    else
                    {
                        throw new Exception(checkUser.Errors.ToString());
                    }

                    auxRoleCount += 1;

                    if (auxRoleCount == 4) { auxRoleCount = 1; }
                }
            }
        }
    }
}
