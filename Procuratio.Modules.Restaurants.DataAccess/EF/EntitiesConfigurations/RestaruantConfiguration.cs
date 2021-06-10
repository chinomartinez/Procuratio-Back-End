using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Restaurants.Domain.Entities;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.EntitiesConfigurations
{
    internal class RestaruantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(x => x.Name).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.HasIndex(x => new { x.Name }).IsUnique(true);

            builder.Property(x => x.Slogan).HasMaxLength(30).IsRequired();
        }
    }
}
