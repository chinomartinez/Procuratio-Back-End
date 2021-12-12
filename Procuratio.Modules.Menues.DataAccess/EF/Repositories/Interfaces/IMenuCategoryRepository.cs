﻿using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces
{
    public interface IMenuCategoryRepository : IBaseRepositoryOperations<MenuCategory, int>
    {
        Task<int> GetNextOrderAsync();

        Task<List<MenuCategory>> GetAllAsync();
    }
}