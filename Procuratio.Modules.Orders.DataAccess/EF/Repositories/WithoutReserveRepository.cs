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
    internal class WithoutReserveRepository : IWithoutReserveRepository
    {
        private readonly OrderDbContext _ordersDbContext;
        private readonly DbSet<WithoutReserve> _withoutReserve;

        public WithoutReserveRepository(OrderDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _withoutReserve = ordersDbContext.WithoutReserve;
        }

        public async Task<WithoutReserve> GetAsync(int id)
        {
            return await _withoutReserve.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WithoutReserve> GetWithTableXWithoutReserveAsync(int id)
        {
            return await _withoutReserve.Include(x => x.TableXWithoutReserve).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<WithoutReserve>> BrowseAsync()
        {
            return await _withoutReserve.Where(x => x.WithoutReserveStateId == (short)WithoutReserveState.State.InProgress)
                .Include(x => x.Order)
                .Include(x => x.WithoutReserveState)
                .Include(x => x.TableXWithoutReserve).ThenInclude(x => x.Table)
                .OrderByDescending(x => x.Order.Date)
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(WithoutReserve withoutReserve)
        {
            _withoutReserve.Update(withoutReserve);
            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task AddAsync(WithoutReserve toCreate)
        {
            await _withoutReserve.AddAsync(toCreate);

            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(WithoutReserve entity)
        {
            _withoutReserve.Remove(entity);
            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task<WithoutReserve> GetEntityEditionFormInitializerAsync(int id)
        {
            return await _withoutReserve.Include(x => x.TableXWithoutReserve).ThenInclude(x => x.Table)
                .AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<WithoutReserve>> GetByIdsAsync(List<int> ids) => await _withoutReserve.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
