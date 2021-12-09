using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.DataAccess.EF.Seeds;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.ModelBuilderExtensions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess
{
    internal class SecurityDbContext : IdentityDbContext<User, Role, int, UserClaim,
                                       UserXRole, UserLogin, RoleClaim, UserToken>, ISeed
    {
        internal const string SecuritySchemeName = "Security";
        internal static int BranchId { get; private set; }

        public DbSet<UserState> UserState { get; set; }

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options, ITenantService tenantService) : base(options) 
        {
            BranchId = tenantService.GetBranchId();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SecuritySchemeName);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            //
            //modelBuilder.ApplyGlobalFilters<IRestaurant>(e => e.BranchId == BranchId);
            //modelBuilder.ApplyGlobalMetadata<IRestaurant>(nameof(BranchId));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IRestaurant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = BranchId;
                        break;
                }
            }

            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IRestaurant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = BranchId;
                        break;
                }
            }

            int result = base.SaveChanges();

            return result;
        }

        public void Seed() => SecuritiesSeedStart.CreateSeeds(this);
    }
}
