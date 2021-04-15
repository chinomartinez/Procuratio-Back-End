using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities.State;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations.State
{
    public class DinerInStateConfiguration : IEntityTypeConfiguration<DinerInState>
    {
        public void Configure(EntityTypeBuilder<DinerInState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
