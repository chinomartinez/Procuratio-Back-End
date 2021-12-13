using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations
{
    internal class CustomUserManager : UserManager<User>
    {
        private readonly CustomUserStore _store;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IEnumerable<IUserValidator<User>> _userValidators;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly IdentityErrorDescriber _errors;
        private readonly IServiceProvider _services;
        private readonly ILogger<CustomUserManager> _logger;

        public CustomUserManager(CustomUserStore store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<CustomUserManager> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _store = store;
            _optionsAccessor = optionsAccessor;
            _passwordHasher = passwordHasher;
            _userValidators = userValidators;
            _passwordValidators = passwordValidators;
            _keyNormalizer = keyNormalizer;
            _errors = errors;
            _services = services;
            _logger = logger;
        }

        public async Task<User> FindByNameAsyncIgnoringQueryFilters(string userName)
        {
            ThrowIfDisposed();

            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            userName = NormalizeKey(userName);

            User user = await _store.FindByNameAsyncIgnoringQueryFilters(userName, CancellationToken);

            // Need to potentially check all keys
            if (user == null && Options.Stores.ProtectPersonalData)
            {
                ILookupProtectorKeyRing keyRing = _services.GetService<ILookupProtectorKeyRing>();
                ILookupProtector protector = _services.GetService<ILookupProtector>();

                if (keyRing != null && protector != null)
                {
                    foreach (var key in keyRing.GetAllKeyIds())
                    {
                        var oldKey = protector.Protect(key, userName);
                        user = await Store.FindByNameAsync(oldKey, CancellationToken);
                        if (user != null)
                        {
                            return user;
                        }
                    }
                }
            }

            return user;
        }

        /// <summary>
        /// Normalize a key (user name, email) for consistent comparisons.
        /// </summary>
        /// <param name="key">The key to normalize.</param>
        /// <returns>A normalized value representing the specified <paramref name="key"/>.</returns>
        public virtual string NormalizeKey(string key)
        {
            return (KeyNormalizer == null) ? key : _keyNormalizer.NormalizeName(key);
        }
    }
}
