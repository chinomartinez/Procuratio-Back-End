using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    internal class MenuSubCategoryConfiguration : IEntityTypeConfiguration<MenuSubcategory>
    {
        public void Configure(EntityTypeBuilder<MenuSubcategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(x => new { x.BranchId, x.Name }).IsUnique();
            builder.HasIndex(x => new { x.BranchId, x.Order, x.MenuCategoryId }).IsUnique();
        }
    }
}
