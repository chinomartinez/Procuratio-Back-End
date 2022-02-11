﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrderInProgressAsync();

        Task<Orders.Domain.Entities.Order> GetWithOrderDetailAsync(int id);

        Task UpdateAsync(Orders.Domain.Entities.Order toUpdate);

        Task<IReadOnlyList<Orders.Domain.Entities.Order>> GetOrdersInProgressForKitchenAsync();

        Task<Orders.Domain.Entities.Order> GetOrderForUpdateOrderDetailAsync(int id);

        Task<Orders.Domain.Entities.Order> GetOrderForUpdateOrderDetailFromCustomerAsync(int id, int branchId);

        Task<Orders.Domain.Entities.Order> GetOrderDetailForKitchenAsync(int id);

        Task<Orders.Domain.Entities.Order> GetOrderDetailForBillAsync(int id);

        Task<List<string>> GetTablesForWaiterNotification(int id, int branchId);

        Task<int?> GetWaiterIdOfTheOrder(int id, int branchId);
    }
}
