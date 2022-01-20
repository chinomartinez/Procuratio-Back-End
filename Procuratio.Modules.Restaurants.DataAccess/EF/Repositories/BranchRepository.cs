using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurants.DataAccess;
using Procuratio.Modules.Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Image = x.Restaurant.Image

            }).FirstAsync(x => x.Id == branchId);
        }
    }
}
