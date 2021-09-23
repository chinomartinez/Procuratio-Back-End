using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Procuratio.Modules.Customers.DataAccess.EF.EntitiesConfigurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
        {
            builder.Property(x => x.BranchId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);

            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired(true);

            builder.Property(x => x.Phone).HasMaxLength(10).IsRequired(true);
        }
    }
}
