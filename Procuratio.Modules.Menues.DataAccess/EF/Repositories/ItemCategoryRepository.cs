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
    internal class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly MenuDbContext _menuDbContext;
        private readonly DbSet<ItemCategory> _itemCategory;

        public ItemCategoryRepository(MenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
            _itemCategory = menuDbContext.ItemCategory;
        }

        public async Task AddAsync(ItemCategory toAdd)
        {
            toAdd.BranchId = TGRID.BranchId;

            await _itemCategory.AddAsync(toAdd);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ItemCategory>> BrowseAsync() => await _itemCategory.Where(x => x.BranchId == TGRID.BranchId).AsNoTracking().ToListAsync();

        public async Task DeleteAsync(ItemCategory entity)
        {
            _itemCategory.Remove(entity);
            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<ItemCategory> GetAsync(int id) => await _itemCategory.SingleOrDefaultAsync(x => x.Id == id && TGRID.BranchId == x.BranchId);

        public async Task<List<ItemCategory>> GetByIdsAsync(List<int> ids) => await _itemCategory.Where(x => TGRID.BranchId == x.BranchId && ids.Contains(x.Id)).ToListAsync();

        public async Task<ItemCategory> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(ItemCategory toUpdate)
        {
            _itemCategory.Update(toUpdate);

            await _menuDbContext.SaveChangesAsync();
        }
    }
}
