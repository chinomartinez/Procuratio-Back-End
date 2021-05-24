using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations
{
    internal class RestaruantConfiguration : IEntityTypeConfiguration<Restaruant>
    {
        public void Configure(EntityTypeBuilder<Restaruant> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Address).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Slogan).HasMaxLength(30).IsRequired();
        }
    }
}
