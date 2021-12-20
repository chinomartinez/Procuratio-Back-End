using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Modules.Orders.Domain.Entities.State;
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

        public async Task<Orders.Domain.Entities.Order> GetOrderForUpdateOrderDetailAsync(int id)
        {
            return await _order.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Orders.Domain.Entities.Order toUpdate)
        {
            _order.Update(toUpdate);

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrderInProgressAsync()
        {
            return await _order
                .Include(x => x.TableXOrders).ThenInclude(x => x.Table)
                .Include(x => x.OrderState)
                .Where(x => x.OrderStateId != (short)OrderState.State.Paid)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrdersInProgressForKitchenAsync()
        {
            return await _order.Include(x => x.OrderDetails).Where(x => x.OrderStateId == (short)OrderState.State.InProgress)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Orders.Domain.Entities.Order> GetWithOrderDetailAsync(int Id)
        {
            return await _order.Include(x => x.OrderDetails).SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Orders.Domain.Entities.Order> GetOrderDetailForKitchenAsync(int id)
        {
            return await _order.Include(x => x.OrderDetails).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
