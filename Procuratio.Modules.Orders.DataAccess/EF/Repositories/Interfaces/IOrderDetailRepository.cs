using Procuratio.Modules.Orders.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces
{
    internal interface IOrderDetailRepository
    {
        Task<IReadOnlyList<OrderDetail>> GetOrderDetailAsync(int id);
        Task<OrderDetail> GetOrderDetailByOrderIdAndItemId(int orderId, int itemId);

        Task<int> DeleteOrderDetail(OrderDetail entity);
    }
}
