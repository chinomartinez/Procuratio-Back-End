using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Customers.Domain.Entities.State;

namespace Procuratio.Modules.Customers.DataAccess.EF.EntitiesConfigurations.State
{
    public class CustomerXOrderStateConfiguration : IEntityTypeConfiguration<CustomerXOrderState>
    {
        public void Configure(EntityTypeBuilder<CustomerXOrderState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
