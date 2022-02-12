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
            await _item.AddAsync(toAdd);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Item>> BrowseAsync() => await _item.AsNoTracking()
            .OrderByDescending(x => x.Name).ToListAsync();

        public async Task DeleteAsync(Item entity)
        {
            _item.Remove(entity);
            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<Item> GetAsync(int id) => await _item.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Item>> GetByIdsAsync(List<int> ids) => await _item.Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task<Item> GetEntityEditionFormInitializerAsync(int id) => await _item.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Item toUpdate)
        {
            _item.Update(toUpdate);

            await _menuDbContext.SaveChangesAsync();
        }

        public async Task<int> GetNextOrderAsync(int menuCategoryId)
        {
            int? lastOrder = await _item.Where(x => x.MenuCategoryId == menuCategoryId)
                .MaxAsync<Item, int?>(x => x.Order);

            return lastOrder is null ? 0 : (int)++lastOrder;
        }

        public async Task<IReadOnlyList<Item>> GetMenuAddItemsToOrderAsync()
        {
            return await _item.Include(x => x.MenuCategory)
                .Where(x => x.ItemStateId == (short)ItemState.State.Available
                && x.MenuCategory.MenuCategoryStateId == (short)MenuCategoryState.State.Available)
                .OrderByDescending(x => x.MenuCategory.Order).ThenByDescending(x => x.Order)
                .ThenByDescending(x => x.Order).AsNoTracking().ToListAsync();
        }

        public async Task<List<MenuForOrderDetail>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn)
        {
            return await _item.Where(x => itemIds.Contains(x.Id))
                .Select(x => new MenuForOrderDetail
                {
                    ItemId = x.Id,
                    ItemName = x.Name,
                    ForKitchen = x.ForKitchen,
                    Price = dineIn ? (decimal)x.PriceInsideRestaurant : (decimal)x.PriceOutsideRestaurant

                }).AsNoTracking().ToListAsync();
        }

        public async Task<List<ItemsForOrderDetailInKitchen>> GetItemsForKitchenAsync(List<int> itemIds)
        {
            return await _item.Where(x => itemIds.Contains(x.Id))
                .Select(x => new ItemsForOrderDetailInKitchen
                {
                    Id = x.Id,
                    Name = x.Name

                }).AsNoTracking().ToListAsync();
        }

        public async Task<List<ItemsBill>> GetItemsFoBillAsync(List<int> itemIds, bool dineIn)
        {
            return await _item.Where(x => itemIds.Contains(x.Id))
                .Select(x => new ItemsBill
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = dineIn ? (decimal)x.PriceInsideRestaurant : (decimal)x.PriceOutsideRestaurant

                }).AsNoTracking().ToListAsync();
        }

        public async Task<List<ItemsBill>> GetAnonymousItemsFoBillAsync(List<int> itemIds, int branchId)
        {
            return await _item.IgnoreQueryFilters().Where(x => itemIds.Contains(x.Id) && x.BranchId == branchId)
                .Select(x => new ItemsBill
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = (decimal)x.PriceInsideRestaurant

                }).AsNoTracking().ToListAsync();
        }
    }
}
