using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Orders.Domain.Entities;

namespace Procuratio.Modules.Orders.DataAccess.EF.EntitiesConfigurations
{
    public class TakeAwayConfiguration : IEntityTypeConfiguration<TakeAway>
    {
        public void Configure(EntityTypeBuilder<TakeAway> builder)
        {
        }
    }
}
