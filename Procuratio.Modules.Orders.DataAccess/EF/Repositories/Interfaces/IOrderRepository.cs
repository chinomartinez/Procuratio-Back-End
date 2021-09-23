using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Orders.Domain.Entities.Order> GetWithoutReserveOrderDetailAsync(int orderId);
    }
}
