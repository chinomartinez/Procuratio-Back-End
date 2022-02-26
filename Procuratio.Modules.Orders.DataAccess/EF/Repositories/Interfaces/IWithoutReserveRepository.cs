using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces
{
    public interface IWithoutReserveRepository : IBaseRepositoryOperations<WithoutReserve, int>
    {
        Task<WithoutReserve> GetWithTableXWithoutReserveAsync(int id);

        Task<string> OnlineMenuAuth(int orderId, int branchId);
        Task<WithoutReserve> GetWithoutReserveForDeleteAsync(int id);
    }
}
