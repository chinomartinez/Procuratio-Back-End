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
        private readonly ITenantService _tenantService;

        public DbSet<UserState> UserState { get; set; }

        public SecurityDbContext(DbContextOptions<SecurityDbContext> options, ITenantService tenantService) : base(options) 
        {
            _tenantService = tenantService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SecuritySchemeName);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            // Da problemas ya que no me deja borrar los filtros globales con identity para metodos anonimos
            //modelBuilder.ApplyTenantConfiguration(x => x.BranchId == _tenantService.GetBranchId());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int branchId = _tenantService.GetBranchId();

            foreach (var entry in ChangeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = branchId;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            int branchId = _tenantService.GetBranchId();

            foreach (var entry in ChangeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.BranchId = branchId;
                        break;
                }
            }

            return base.SaveChanges();
        }

        public void Seed() => SecuritiesSeedStart.CreateSeeds(this);
    }
}
