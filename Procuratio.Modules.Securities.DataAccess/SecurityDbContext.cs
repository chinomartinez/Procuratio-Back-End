using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.DataAccess.EF.Seeds;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Securities.DataAccess
{
    internal class SecurityDbContext : IdentityDbContext<User, Role, int, UserClaim,
                                       UserXRole, UserLogin, RoleClaim, UserToken>, ISeed
    {
        internal const string SecuritySchemeName = "Security";

        public DbSet<UserState> UserState { get; set; }

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SecuritySchemeName);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public void Seed() => SecuritiesSeedStart.CreateSeeds(this);
    }
}
