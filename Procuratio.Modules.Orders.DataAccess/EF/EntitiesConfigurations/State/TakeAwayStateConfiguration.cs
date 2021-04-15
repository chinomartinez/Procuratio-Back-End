using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.State
{
    public class TakeAwayStateConfiguration : IEntityTypeConfiguration<TakeAwayState>
    {
        public void Configure(EntityTypeBuilder<TakeAwayState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
