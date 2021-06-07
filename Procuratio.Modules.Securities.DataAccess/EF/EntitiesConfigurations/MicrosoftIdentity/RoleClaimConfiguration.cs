using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;

namespace Procuratio.Modules.Securities.DataAccess.EF.EntitiesConfigurations.MicrosoftIdentity
{
    internal class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable(nameof(RoleClaim).ToString(), SecuritiesDbContext.SecuritesSchemeName);
        }
    }
}
