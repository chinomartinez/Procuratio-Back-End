using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Procuratio.Modules.Securities.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.DataAccess.EF.EntitiesConfigurations
{
    internal class UserStateConfiguration : IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            builder.HasData(
                new UserState() { Id = (short)UserState.State.Active, StateName = "Activo" },
                new UserState() { Id = (short)UserState.State.Withdrawn, StateName = "Dado de baja" });
        }
    }
}
