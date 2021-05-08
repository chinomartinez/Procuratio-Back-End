using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    internal class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItem>
    {
        public void Configure(EntityTypeBuilder<CategoryItem> builder)
        {
            builder.Property(x => x.CategoryItemName).HasMaxLength(50).IsRequired();
        }
    }
}
