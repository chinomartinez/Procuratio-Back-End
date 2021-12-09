using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations.MicrosoftIdentity
{
    internal class UserXRolConfiguration : IEntityTypeConfiguration<UserXRole>
    {
        public void Configure(EntityTypeBuilder<UserXRole> builder)
        {
            builder.ToTable(nameof(UserXRole), SecurityDbContext.SecuritySchemeName);
        }
    }
}
