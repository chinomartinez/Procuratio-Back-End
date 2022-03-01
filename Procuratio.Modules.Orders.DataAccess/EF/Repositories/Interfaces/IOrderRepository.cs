using Procuratio.Modules.Order.DataAccess.EF.Repositories.Models;
using System.Collections.Generic;
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

        Task<Orders.Domain.Entities.Order> GetAnonymousOrderDetailForBillAsync(int id, int branchId);

        Task<short> GetOrderStateIdAsync(int v1, int v2);

        Task<Orders.Domain.Entities.Order> GetAnonymousOrderAsync(int orderId, int branchId);

        Task<List<OrderForReport>> GetOrderForReport(int from, int to);

        Task<List<ItemForReport>> GetItemForBestSelling(int topBestSellingItems);

        Task<List<ItemForReport>> GetItemForWorstSelling(int topWorstSellingItems);
    }
}
