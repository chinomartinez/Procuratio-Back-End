using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces
{
    public interface ITableRepository : IBaseRepositoryOperations<Table, int>
    {
        Task<short?> GetLastNumberAsync();

        Task<List<Table>> GetAvailablesTablesAsync();

        Task SetTablesStateAsync(List<int> tablesIds, TableState.State newState);
    }
}
