using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
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

        public TableRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            _table = orderDbContext.Table;
        }

        public async Task AddAsync(Table toAdd)
        {
            await _table.AddAsync(toAdd);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Table>> BrowseAsync() => await _table.AsNoTracking().ToListAsync();

        public async Task<Table> GetEntityEditionFormInitializerAsync(int Id)
        {
            return await _table.Include(x => x.TableState).AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task DeleteAsync(Table entity)
        {
            _table.Remove(entity);
            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<Table> GetAsync(int Id) => await _table.SingleOrDefaultAsync(x => x.Id == Id);

        public async Task<short?> GetLastNumberAsync()
        {
            return await Task.FromResult(_table.MaxAsync<Table, short?>(x => x.Number)).Result;
        }

        public async Task UpdateAsync(Table toUpdate)
        {
            _table.Update(toUpdate);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<List<Table>> GetAvailablesTablesAsync()
        {
            return await _table.Include(x => x.TableXWithoutReserve).ThenInclude(x => x.WithoutReserve).ThenInclude(x => x.Order)
                .Include(x => x.TableXReserve).ThenInclude(x => x.Reserve).ThenInclude(x => x.Order)
                .Where(x => !x.TableXWithoutReserve.Any(x => x.WithoutReserve.Order.OrderStateId != (short)OrderState.State.Paid)
                && !x.TableXReserve.Any(x => x.Reserve.Order.OrderStateId != (short)OrderState.State.Paid))
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<Table>> GetByIdsAsync(List<int> ids) => await _table.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
