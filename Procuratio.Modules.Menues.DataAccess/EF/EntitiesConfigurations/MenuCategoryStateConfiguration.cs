using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.DataAccess.EF.EntitiesConfigurations
{
    internal class MenuCategoryStateConfiguration : IEntityTypeConfiguration<MenuCategoryState>
    {
        public void Configure(EntityTypeBuilder<MenuCategoryState> builder)
        {
            builder.HasData(
                new MenuCategoryState() { Id = (short)MenuCategoryState.State.Available, StateName = "Disponible" },
                new MenuCategoryState() { Id = (short)MenuCategoryState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
