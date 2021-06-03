﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories
{
    internal class DineInRepository : IDineInRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        private readonly DbSet<DineIn> _dineIn;

        public DineInRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _dineIn = ordersDbContext.DineIn;
        }

        public async Task<DineIn> GetAsync(int id)
        {
            return await _dineIn.SingleOrDefaultAsync(x => x.ID == id && TGRID.RestaurantID == x.RestaurantID);
        }

        public async Task<IReadOnlyList<DineIn>> BrowseAsync()
        {
            return await _dineIn.Where(x => x.RestaurantID == TGRID.RestaurantID).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(DineIn dineIn)
        {
            _dineIn.Update(dineIn);

            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task AddAsync(DineIn toCreate)
        {
            toCreate.RestaurantID = TGRID.RestaurantID;
            toCreate.Order.RestaurantID = TGRID.RestaurantID;

            await _dineIn.AddAsync(toCreate);

            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(DineIn entity)
        {
            await Task.FromResult(_dineIn.Remove(entity));
        }
    }
}