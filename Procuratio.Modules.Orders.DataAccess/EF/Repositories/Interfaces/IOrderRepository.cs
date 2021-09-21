using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Orders.Domain.Entities.Order> GetWithoutReserveOrderDetailAsync(int orderId);
    }
}
