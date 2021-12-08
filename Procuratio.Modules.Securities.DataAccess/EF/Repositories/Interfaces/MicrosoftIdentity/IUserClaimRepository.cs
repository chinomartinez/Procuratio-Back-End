using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity
{
    public interface IUserClaimRepository : IBaseRepositoryOperations<UserClaim, int>
    {
        Task<IReadOnlyList<UserClaim>> GetAll();
    }
}
