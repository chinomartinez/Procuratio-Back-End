using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    internal class WithoutReserveConfiguration : IEntityTypeConfiguration<WithoutReserve>
    {
        public void Configure(EntityTypeBuilder<WithoutReserve> builder)
        {
            builder.Property(x => x.Password).HasMaxLength(200).IsRequired();
        }
    }
}
