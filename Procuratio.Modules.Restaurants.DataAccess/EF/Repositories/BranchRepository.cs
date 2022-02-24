using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurant.Domain.Entities;
using Procuratio.Modules.Restaurants.DataAccess;
using Procuratio.Modules.Restaurants.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Repositories
{
    internal class BranchRepository : IBranchRepository
    {
        private readonly RestaurantDbContext _restaurantDbContext;
        private readonly DbSet<Branch> _branch;

        public BranchRepository(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
            _branch = restaurantDbContext.Branch;
        }

        public async Task<BranchForMenuModel> GetBranchForMenu(int branchId)
        {
            return await _branch.IgnoreQueryFilters().Select(x => new BranchForMenuModel()
            {
                Id = x.Id,
                Name = x.Restaurant.Name,
                Slogan = x.Restaurant.Slogan,
                Phone = x.Phone,
                Address = x.Address,
                Image = x.Restaurant.Image,
                Location = x.Location,
                Instagram = x.Instagram

            }).FirstAsync(x => x.Id == branchId);
        }

        public async Task<List<SettingsModel>> GetSettings(int branchId)
        {
            return await _branch.IgnoreQueryFilters().Where(x => x.BranchSettings.Any(x => x.BranchId == branchId)).SelectMany(c => c.BranchSettings, (c, i) =>
                           new SettingsModel()
                           {
                               SettingId = i.SettingId,
                               BranchId = i.BranchId,
                               Description = i.Setting.Description,
                               DataType = i.Setting.DataType,
                               Value = i.UnconstrainedValue,
                               Caption = i.Setting.AllowedSettingValues.FirstOrDefault(x => x.SettingId == i.SettingId).Caption,
                               MinValue = i.Setting.MinValue,
                               MaxValue = i.Setting.MaxValue

                           }).ToListAsync();
        }

        public async Task<Branch> GetBranchForUpdateSettings(int branchId)
        {
            return await _branch.IgnoreQueryFilters().Where(x => x.Id == branchId)
                .Include(x => x.BranchSettings)
                .ThenInclude(x => x.Setting)
                .ThenInclude(x => x.AllowedSettingValues)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateSettings(Branch branch)
        {
            _branch.Update(branch);

            await _restaurantDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistBranchId(int branchId)
        {
            return await _branch.FirstOrDefaultAsync(x => x.Id == branchId) is not null;
        }

        public async Task<List<RestaurantForOnlineMenuModel>> GetRestaurantsForOnlineMenu()
        {
            return await _branch.IgnoreQueryFilters()
                .Include(x => x.Restaurant)
                .Include(x => x.BranchSettings).ThenInclude(x => x.Setting)
                .Where(x => x.BranchSettings.Any(x => x.SettingId == (int)BranchSetting.Type.OnlineMenu && x.UnconstrainedValue == true.ToString().ToLower())) // cambiar el type
                .Select(x => new RestaurantForOnlineMenuModel
                {
                    BranchId = x.Id,
                    Name = x.Restaurant.Name,
                    Slogan = x.Restaurant.Slogan,
                    Adress = x.Address
                })
                .ToListAsync();
        }
    }
}
