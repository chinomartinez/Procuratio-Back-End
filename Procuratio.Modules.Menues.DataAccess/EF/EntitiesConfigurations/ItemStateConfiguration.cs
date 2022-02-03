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
    internal class ItemStateConfiguration : IEntityTypeConfiguration<ItemState>
    {
        public void Configure(EntityTypeBuilder<ItemState> builder)
        {
            builder.HasData(
                new ItemState() { Id = (short)ItemState.State.Available, StateName = "Disponible" },
                new ItemState() { Id = (short)ItemState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
