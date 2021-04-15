using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations
{
    public class RestaruantConfiguration : IEntityTypeConfiguration<Restaruant>
    {
        public void Configure(EntityTypeBuilder<Restaruant> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
