using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Customers.Domain.Entities;

namespace Procuratio.Modules.Customers.DataAccess.EF.EntitiesConfigurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.BranchID).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);

            builder.Property(x => x.Surname).HasMaxLength(50).IsRequired(true);

            builder.Property(x => x.Phone).HasMaxLength(10).IsRequired(true);
        }
    }
}
