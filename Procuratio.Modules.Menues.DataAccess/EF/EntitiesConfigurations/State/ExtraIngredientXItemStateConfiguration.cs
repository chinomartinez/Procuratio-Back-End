using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities.State;

namespace Procuratio.Modules.Menues.DataAccess.EF.EntitiesConfigurations.State
{
    public class ExtraIngredientXItemStateConfiguration : IEntityTypeConfiguration<ExtraIngredientXItemState>
    {
        public void Configure(EntityTypeBuilder<ExtraIngredientXItemState> builder)
        {
            builder.Property(x => x.StateName).HasMaxLength(30).IsRequired();
        }
    }
}
