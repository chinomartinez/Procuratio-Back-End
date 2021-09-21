using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _ordersDbContext;
        private readonly DbSet<Orders.Domain.Entities.Order> _order;

        public OrderRepository(OrderDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
            _order = ordersDbContext.Order;
        }

        public async Task<Orders.Domain.Entities.Order> GetWithoutReserveOrderDetailAsync(int orderId)
        {
            return await BaseRelationsForGetAnOrderDetail().Include(x => x.WithoutReserve)
                .FirstOrDefaultAsync(x => x.BranchID == TGRID.BranchID && x.WithoutReserve.OrderID == orderId);
        }

        private IQueryable<Orders.Domain.Entities.Order> BaseRelationsForGetAnOrderDetail() => _order.Include(x => x.OrderDetails).Include(x => x.OrderState).AsQueryable();
    }
}
