﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class CategoryItemStateSeed
    {
        internal static void StartCategoryItemStateSeed(DbSet<CategoryItemState> categoryItemStateDbSet)
        {
            if (categoryItemStateDbSet.Any()) return;

            categoryItemStateDbSet.Add(new CategoryItemState() { ID = (int)CategoryItemState.State.Available, StateName = "Disponible" });

            categoryItemStateDbSet.Add(new CategoryItemState() { ID = (int)CategoryItemState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
