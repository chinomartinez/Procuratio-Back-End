using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private readonly MenuDbContext _menuDbContext;
        private readonly DbSet<Item> _item;

        public ItemRepository(MenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
            _item = menuDbContext.Item;
        }

        public async Task AddAsync(Item toAdd)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<Item>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(Item entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Item> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Item>> GetByIdsAsync(List<int> ids) => await _item.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<Item> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(Item toUpdate)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<Item>> GetMenuAsync()
        {
            return await _item.Include(x => x.ItemSubCategory).ThenInclude(x => x.ItemCategory)
                .Where(x => x.ItemStateId == (short)ItemState.State.Available && x.ItemSubCategory.ItemSubCategoryStateId == (short)ItemSubCategoryState.State.Available
                && x.ItemSubCategory.ItemCategory.ItemCategoryStateId == (short)ItemCategoryState.State.Available)
                .OrderByDescending(x => x.ItemSubCategory.ItemCategory.Order)
                .ThenByDescending(x => x.ItemSubCategory.Order).ThenByDescending(x => x.Order)
                .ThenByDescending(x => x.Order).ToListAsync();
        }
    }
}
