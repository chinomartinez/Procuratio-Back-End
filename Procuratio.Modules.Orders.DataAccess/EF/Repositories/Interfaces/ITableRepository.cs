using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces
{
    public interface ITableRepository : IBaseRepositoryOperations<Table, int>
    {
        Task<short> GetNextNumberAsync();

        Task<List<Table>> GetAvailablesTablesAsync();
    }
}
