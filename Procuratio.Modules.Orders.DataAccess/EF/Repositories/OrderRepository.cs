using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly DbSet<Orders.Domain.Entities.Order> _order;

        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            _order = orderDbContext.Order;
        }

        public async Task<Orders.Domain.Entities.Order> GetWithoutReserveOrderDetailAsync(int orderId)
        {
            return await BaseRelationsForGetAnOrderDetail().Include(x => x.WithoutReserve)
                .FirstOrDefaultAsync(x => x.BranchId == TGRID.BranchId && x.WithoutReserve.OrderId == orderId);
        }

        public async Task UpdateAsync(Orders.Domain.Entities.Order toUpdate)
        {
            _order.Update(toUpdate);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrdersInProgressAsync()
        {
            return await _order.Include(x => x.OrderDetails).Where(x => x.OrderStateId == (short)OrderState.State.InProgress)
                .AsNoTracking().ToListAsync();
        }

        private IQueryable<Orders.Domain.Entities.Order> BaseRelationsForGetAnOrderDetail() => _order.Include(x => x.OrderDetails).Include(x => x.OrderState).AsQueryable();
    }
}
