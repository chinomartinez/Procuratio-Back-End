using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Shared
{
    public interface IOrderModuleAPI
    {
        Task<List<string>> GetTablesForWaiterNotification(string customerPassword);
        Task<int?> GetWaiterIdOfTheOrder(string orderKey);
    }
}
