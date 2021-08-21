using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories
{
    internal class TableRepository : ITableRepository
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly DbSet<Table> _table;

        public TableRepository(OrderDbContext ordersDbContext)
        {
            _orderDbContext = ordersDbContext;
            _table = ordersDbContext.Table;
        }

        public async Task AddAsync(Table toAdd)
        {
            toAdd.BranchID = TGRID.BranchID;

            await _table.AddAsync(toAdd);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Table>> BrowseAsync()
        {
            return await _table.Include(x => x.TableState).Where(x => x.BranchID == TGRID.BranchID).AsNoTracking().ToListAsync();
        }

        public async Task<Table> GetEntityEditionFormInitializerAsync(int ID)
        {
            return await _table.Include(x => x.TableState).AsNoTracking().SingleOrDefaultAsync(x => x.ID == ID && TGRID.BranchID == x.BranchID);
        }

        public async Task DeleteAsync(Table entity)
        {
            _table.Remove(entity);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<Table> GetAsync(int ID)
        {
            return await _table.SingleOrDefaultAsync(x => x.ID == ID && TGRID.BranchID == x.BranchID);
        }

        public async Task<short?> GetLastNumberAsync()
        {
            return await Task.FromResult(_table.Where(x => TGRID.BranchID == x.BranchID).MaxAsync<Table, short?>(x => x.Number)).Result;
        }

        public async Task UpdateAsync(Table toUpdate)
        {
            _table.Update(toUpdate);

            await _orderDbContext.SaveChangesAsync();
        }
    }
}
