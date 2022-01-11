using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Repositories
{
    internal class MenuSubcategoryRepository : IMenuSubcategoryRepository
    {
        private readonly MenuDbContext _menuDbContext;
        private readonly DbSet<MenuSubcategory> _menuSubcategory;

        public MenuSubcategoryRepository(MenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
            _menuSubcategory = menuDbContext.MenuSubCategory;
        }

        public async Task AddAsync(MenuSubcategory toAdd)
        {
            await _menuSubcategory.AddAsync(toAdd);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<MenuSubcategory>> BrowseAsync() => await _menuSubcategory.Include(x => x.MenuCategory).AsNoTracking()
            .OrderByDescending(x => x.MenuCategoryId).ThenBy(x => x.Order).ToListAsync();

        public async Task DeleteAsync(MenuSubcategory entity)
        {
            _menuSubcategory.Remove(entity);
            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<MenuSubcategory> GetAsync(int id) => await _menuSubcategory.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<MenuSubcategory>> GetByIdsAsync(List<int> ids) => await _menuSubcategory.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<MenuSubcategory> GetEntityEditionFormInitializerAsync(int id) => await _menuSubcategory.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(MenuSubcategory toUpdate)
        {
            _menuSubcategory.Update(toUpdate);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<List<MenuSubcategory>> GetAllAsync() => await _menuSubcategory.ToListAsync();

        public async Task<int> GetNextOrderAsync(int menuCategoryId)
        {
            int? lastOrder = await _menuSubcategory.Where(x => x.MenuCategoryId == menuCategoryId)
                .MaxAsync<MenuSubcategory, int?>(x => x.Order);

            return lastOrder is null ? 0 : (int)++lastOrder;
        }
    }
}
