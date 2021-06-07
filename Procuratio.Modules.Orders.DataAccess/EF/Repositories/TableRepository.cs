using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories
{
    internal class TableRepository : ITableRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        private readonly DbSet<Table> _table;

        public TableRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _table= ordersDbContext.Table;
        }

        public async Task AddAsync(Table toCreate)
        {
            toCreate.BranchID = TGRID.BranchID;

            await _table.AddAsync(toCreate);

            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Table>> BrowseAsync()
        {
            return await _table.Where(x => x.BranchID == TGRID.BranchID).AsNoTracking().ToListAsync();
        }

        public async Task DeleteAsync(Table entity)
        {
            await Task.FromResult(_table.Remove(entity));
        }

        public async Task<Table> GetAsync(int id)
        {
            return await _table.SingleOrDefaultAsync(x => x.ID == id && TGRID.BranchID == x.BranchID);
        }

        public async Task<short?> GetLastNumberAsync()
        {
            return await Task.FromResult(_table.OrderByDescending(x => x.Number).FirstOrDefaultAsync(x => TGRID.BranchID == x.BranchID).Result.Number);
        }

        public async Task UpdateAsync(Table toUpdate)
        {
            _table.Update(toUpdate);

            await _ordersDbContext.SaveChangesAsync();
        }
    }
}
