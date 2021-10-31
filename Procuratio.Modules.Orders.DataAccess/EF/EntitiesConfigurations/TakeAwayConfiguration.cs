using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    internal class TakeAwayConfiguration : IEntityTypeConfiguration<TakeAway>
    {
        public void Configure(EntityTypeBuilder<TakeAway> builder)
        {
            builder.Property(x => x.BranchId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.HasQueryFilter(x => x.BranchId == OrderDbContext.BranchId);
        }
    }
}
