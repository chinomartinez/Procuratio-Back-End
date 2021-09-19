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
    internal class DineInRepository : IDineInRepository
    {
        private readonly OrderDbContext _ordersDbContext;
        private readonly DbSet<DineIn> _dineIn;

        public DineInRepository(OrderDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _dineIn = ordersDbContext.DineIn;
        }

        public async Task<DineIn> GetAsync(int id)
        {
            return await _dineIn.SingleOrDefaultAsync(x => x.ID == id && TGRID.BranchID == x.BranchID);
        }

        public async Task<DineIn> GetWithTableXDinerInAsync(int id)
        {
            return await _dineIn.Include(x => x.TableXDinerIn).SingleOrDefaultAsync(x => x.ID == id && TGRID.BranchID == x.BranchID);
        }

        public async Task<IReadOnlyList<DineIn>> BrowseAsync()
        {
            return await _dineIn.Where(x => x.BranchID == TGRID.BranchID && x.DinerInStateID == (short)DineInState.State.InProgress)
                .Include(x => x.Order)
                .Include(x => x.DinerInState)
                .Include(x => x.TableXDinerIn).ThenInclude(x => x.Table)
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(DineIn dineIn)
        {
            _dineIn.Update(dineIn);
            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task AddAsync(DineIn toCreate)
        {
            toCreate.BranchID = TGRID.BranchID;
            toCreate.Order.BranchID = TGRID.BranchID;

            await _dineIn.AddAsync(toCreate);

            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(DineIn entity)
        {
            _dineIn.Remove(entity);
            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task<DineIn> GetEntityEditionFormInitializerAsync(int id)
        {
            return await _dineIn.Include(x => x.TableXDinerIn).ThenInclude(x => x.Table)
                .AsNoTracking().SingleOrDefaultAsync(x => x.ID == id && TGRID.BranchID == x.BranchID);
        }

        public async Task<List<DineIn>> GetByIdsAsync(List<int> ids) => await _dineIn.Where(x => TGRID.BranchID == x.BranchID && ids.Contains(x.ID)).ToListAsync();

        public async Task<IReadOnlyList<DineIn>> GetDineInInProgressAsync()
        {
            return await _dineIn.Include(x => x.TableXDinerIn).ThenInclude(x => x.Table)
                .Include(x => x.Order).ThenInclude(x => x.OrderState)
                .Where(x => x.BranchID == TGRID.BranchID && x.DinerInStateID == (short)DineInState.State.InProgress)
                .AsNoTracking().ToListAsync();
        }
    }
}
