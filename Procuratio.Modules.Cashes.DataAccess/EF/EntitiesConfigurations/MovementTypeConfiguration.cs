using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Cashes.Domain.Entities;

namespace Procuratio.Modules.Cashes.DataAccess.EF.EntitiesConfigurations
{
    internal class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>
    {
        public void Configure(EntityTypeBuilder<MovementType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
