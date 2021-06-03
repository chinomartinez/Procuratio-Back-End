using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities;

namespace Procuratio.Modules.Securities.DataAccess.EntitiesConfigurations
{
    internal class RestaruantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasIndex(x => new { x.Name }).IsUnique(true);

            builder.Property(x => x.Address).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Slogan).HasMaxLength(30).IsRequired();
        }
    }
}
