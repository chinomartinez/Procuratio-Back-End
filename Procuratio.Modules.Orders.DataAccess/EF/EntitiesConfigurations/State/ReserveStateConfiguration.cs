using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.State
{
    public class ReserveStateConfiguration : IEntityTypeConfiguration<ReserveState>
    {
        public void Configure(EntityTypeBuilder<ReserveState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
