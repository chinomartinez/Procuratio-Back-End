using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.Domain.Entities;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;

namespace Procuratio.Modules.Securities.DataAccess
{
    public class SecuritiesDbContext : IdentityDbContext<User, Role, int, UserClaim,
                                       UserXRole, UserLogin, RoleClaim, UserToken>
    {
        internal const string SecuritesSchemaName = "Securities";

        public DbSet<Restaruant> Restaruant { get; set; }

        public SecuritiesDbContext(DbContextOptions<SecuritiesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SecuritesSchemaName);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
