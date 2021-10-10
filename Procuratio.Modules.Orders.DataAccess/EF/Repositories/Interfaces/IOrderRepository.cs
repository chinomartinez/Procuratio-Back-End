using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Orders.Domain.Entities.Order> GetWithoutReserveOrderDetailAsync(int orderId);

        Task UpdateAsync(Orders.Domain.Entities.Order toUpdate);

        Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrdersInProgressAsync();
    }
}
