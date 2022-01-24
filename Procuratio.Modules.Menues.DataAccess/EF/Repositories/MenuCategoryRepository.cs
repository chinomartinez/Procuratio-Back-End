using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
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

        public async Task UpdateAsync(MenuCategory toUpdate)
        {
            _menuCategory.Update(toUpdate);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<List<MenuCategory>> GetAllAsync() => await _menuCategory.ToListAsync();

        public async Task<int> GetNextOrderAsync()
        {
            int? lastOrder = await _menuCategory.MaxAsync<MenuCategory, int?>(x => x.Order);

            return lastOrder is null ? 0 : (int)++lastOrder;
        }

        public async Task<IReadOnlyList<MenuModel>> GetMenuAsync()
        {
            return await _menuCategory.Include(x => x.Items)
                .Select(x => new MenuModel
                {
                    MenuCategoryId = x.Id,
                    MenuCategoryName = x.Name,
                    MenuCategoryOrder = x.Order,
                    ItemsModel = x.Items.Select(x => new ItemMenuModel
                    {
                        ItemId = x.Id,
                        ItemName = x.Name,
                        ItemOrder = x.Order
                    }).OrderBy(x => x.ItemOrder).ToList()
                }).OrderBy(x => x.MenuCategoryOrder)
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<MenuCategory>> GetMenuToUpdateAsync()
        {
            return await _menuCategory.Include(x => x.Items).ToListAsync();
        }

        public async Task UpdateMenuAsync(List<MenuCategory> toUpdate)
        {
            try
            {
                _menuCategory.UpdateRange(toUpdate);

                await _menuDbContext.SaveChangesAsync();
            }
            catch (System.Exception e)
            {
                var sdsdsd = e.Message;
            }
        }

        public async Task<IReadOnlyList<OnlineMenuModel>> GetDineInOnlineMenuAsync(int branchId)
        {
            return await _menuCategory.IgnoreQueryFilters().Include(x => x.Items)
                .Where(x => x.BranchId == branchId && x.Items.Count > 0).Select(x => new OnlineMenuModel
                {
                    MenuCategoryName = x.Name,
                    CategoryOrder = x.Order,
                    ItemsModel = x.Items.Where(x => x.PriceInsideRestaurant != null && x.BranchId == branchId).Select(x => new ItemOnlineMenuModel
                    {
                        ItemId = x.Id,
                        ItemName = x.Name,
                        Description = x.Description,
                        ForKitchen = x.ForKitchen,
                        Image = x.Image,
                        Price = (decimal)x.PriceInsideRestaurant,
                        ItemOrder = x.Order
                    }).OrderBy(x => x.ItemOrder).ToList()
                }).OrderBy(x => x.CategoryOrder).AsNoTracking().ToListAsync();
        }
    }
}
