using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Orders.Domain.Entities.Order> GetWithOrderDetailAsync(int id);

        Task<Orders.Domain.Entities.Order> GetWithoutReserveOrderDetailAsync(int id);

        Task UpdateAsync(Orders.Domain.Entities.Order toUpdate);

        Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrdersInProgressAsync();

        Task<List<DateTime>> GetOrderForReport();
    }
}
