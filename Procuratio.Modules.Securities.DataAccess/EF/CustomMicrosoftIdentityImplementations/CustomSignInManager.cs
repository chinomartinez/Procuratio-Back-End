using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations
{
    internal class CustomSignInManager : SignInManager<User>
    {
        private readonly CustomUserManager _userManager;

        public CustomSignInManager(CustomUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<User> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Attempts to sign in the specified <paramref name="user"/> and <paramref name="password"/> combination
        /// as an asynchronous operation.
        /// </summary>
        /// <param name="user">The user to sign in.</param>
        /// <param name="password">The password to attempt to sign in with.</param>
        /// <param name="isPersistent">Flag indicating whether the sign-in cookie should persist after the browser is closed.</param>
        /// <param name="lockoutOnFailure">Flag indicating if the user account should be locked if the sign in fails.</param>
        /// <returns>The task object representing the asynchronous operation containing the <see name="SignInResult"/>
        /// for the sign-in attempt.</returns>
        public async override Task<SignInResult> PasswordSignInAsync(User user, string password,
            bool isPersistent, bool lockoutOnFailure)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var attempt = await CheckPasswordSignInAsync(user, password, lockoutOnFailure);
            return attempt.Succeeded
                ? await SignInOrTwoFactorAsync(user, isPersistent)
                : attempt;
        }
    }
}
