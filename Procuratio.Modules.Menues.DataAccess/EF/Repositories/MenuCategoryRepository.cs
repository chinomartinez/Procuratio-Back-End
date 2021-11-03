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
    internal class MenuCategoryRepository : IMenuCategoryRepository
    {
        private readonly MenuDbContext _menuDbContext;
        private readonly DbSet<MenuCategory> _menuCategory;

        public MenuCategoryRepository(MenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
            _menuCategory = menuDbContext.MenuCategory;
        }

        public async Task AddAsync(MenuCategory toAdd)
        {
            await _menuCategory.AddAsync(toAdd);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<MenuCategory>> BrowseAsync() => await _menuCategory.AsNoTracking()
            .OrderByDescending(x => x.Name).ToListAsync();

        public async Task DeleteAsync(MenuCategory entity)
        {
            _menuCategory.Remove(entity);
            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<MenuCategory> GetAsync(int id) => await _menuCategory.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<MenuCategory>> GetByIdsAsync(List<int> ids) => await _menuCategory.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<MenuCategory> GetEntityEditionFormInitializerAsync(int id) => await _menuCategory.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<int> GetNextOrder()
        {
            int? lastOrder = await _menuCategory.MaxAsync<MenuCategory, int?>(x => x.Order);

            return lastOrder == null ? 1 : (int)++lastOrder;
        }

        public async Task UpdateAsync(MenuCategory toUpdate)
        {
            _menuCategory.Update(toUpdate);

            await _menuDbContext.SaveChangesAsync();
        }
    }
}
