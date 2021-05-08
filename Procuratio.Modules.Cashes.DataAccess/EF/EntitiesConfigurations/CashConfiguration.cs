using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Cashes.Domain.Entities;

namespace Procuratio.Modules.Cashes.DataAccess.EF.EntitiesConfigurations
{
    internal class CashConfiguration : IEntityTypeConfiguration<Cash>
    {
        public void Configure(EntityTypeBuilder<Cash> builder)
        {
            builder.Property(x => x.Mount).HasPrecision(19, 4);

            builder.Property(x => x.Detail).HasMaxLength(100).IsRequired();
        }
    }
}
