using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.DataAccess.EF.Seeds;
using Procuratio.Modules.Cashes.Domain.Entities;
using Procuratio.Modules.Cashes.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.SeedConfiguration.Interfaces;

namespace Procuratio.Modules.Cashes.DataAccess
{
    public class CashesDbContext : DbContext, ISeed
    {
        internal const string CashesSchemaName = "Cashes";

        #region DbSet of entities
        public DbSet<Cash> Cash { get; set; }
        public DbSet<MountType> MountType { get; set; }
        public DbSet<MovementType> MovementType { get; set; }
        #endregion

        #region DbSet of intermediate entities
        #endregion

        #region DbSet of state entities
        public DbSet<CashState> CashState { get; set; }
        #endregion

        public CashesDbContext(DbContextOptions<CashesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CashesSchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed() => CashesSeedStart.CreateSeeds(this);
    }
}
