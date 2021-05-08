using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations
{
    internal class SubCategoryItemConfiguration : IEntityTypeConfiguration<SubCategoryItem>
    {
        public void Configure(EntityTypeBuilder<SubCategoryItem> builder)
        {
            builder.Property(x => x.SubCategoryItemName).HasMaxLength(50).IsRequired();
        }
    }
}
