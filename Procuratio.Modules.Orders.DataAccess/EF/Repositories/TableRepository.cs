using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
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

        public async Task<short> GetNextNumberAsync()
        {
            short? lastNumber = await _table.MaxAsync<Table, short?>(x => x.Number);

            return lastNumber is null ? (short)1 : (short)++lastNumber;
        }

        public async Task UpdateAsync(Table toUpdate)
        {
            _table.Update(toUpdate);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<List<Table>> GetAvailablesTablesAsync()
        {
            return await _table
                //.Include(x => x.TableXOrder).ThenInclude(x => x.Order).ThenInclude(x => x.WithoutReserve)
                //.Include(x => x.TableXOrder).ThenInclude(x => x.Order).ThenInclude(x => x.Reserve)
                .Where(x => !x.TableXOrder.Any(x => x.Order.OrderStateId != (short)OrderState.State.Paid))
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<Table>> GetByIdsAsync(List<int> ids) => await _table.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
