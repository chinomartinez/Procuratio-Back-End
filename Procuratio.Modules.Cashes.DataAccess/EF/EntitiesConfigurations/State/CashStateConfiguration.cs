using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Cashes.Domain.Entities.State;

namespace Procuratio.Modules.Cashes.DataAccess.EF.EntitiesConfigurations.State
{
    public class CashStateConfiguration : IEntityTypeConfiguration<CashState>
    {
        public void Configure(EntityTypeBuilder<CashState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
