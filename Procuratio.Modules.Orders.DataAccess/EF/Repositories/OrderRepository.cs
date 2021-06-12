using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        private readonly DbSet<Order> _order;

        public OrderRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _order = ordersDbContext.Order;
        }

        public async Task AddAsync(Order toAdd)
        {
            toAdd.BranchID = TGRID.BranchID;

            await _order.AddAsync(toAdd);

            await _ordersDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Order>> BrowseAsync()
        {
            return await _order.Where(x => x.BranchID == TGRID.BranchID).AsNoTracking().ToListAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            await Task.FromResult(_order.Remove(entity));
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _order.SingleOrDefaultAsync(x => x.ID == id && TGRID.BranchID == x.BranchID);
        }

        public async Task UpdateAsync(Order toUpdate)
        {
            _order.Update(toUpdate);

            await _ordersDbContext.SaveChangesAsync();
        }
    }
}
