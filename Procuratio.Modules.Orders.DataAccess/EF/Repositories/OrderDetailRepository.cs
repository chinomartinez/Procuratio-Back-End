using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories
{
    internal class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly DbSet<OrderDetail> _orderDetail;

        public OrderDetailRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            _orderDetail = orderDbContext.OrderDetail;
        }

        public async Task<int> DeleteOrderDetail(OrderDetail entity)
        {
            _orderDetail.Remove(entity);
            return await _orderDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<OrderDetail>> GetOrderDetailAsync(int id) => await _orderDetail.Where(x => x.OrderId == id).ToListAsync();

        public async Task<OrderDetail> GetOrderDetailByOrderIdAndItemId(int orderId, int itemId)
        {
            return await _orderDetail.SingleOrDefaultAsync(x => x.ItemId == itemId && x.OrderId == orderId);
        }
    }
}
