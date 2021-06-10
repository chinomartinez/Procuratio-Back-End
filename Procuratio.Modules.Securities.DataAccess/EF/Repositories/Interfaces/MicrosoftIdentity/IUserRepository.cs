using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity
{
    public interface IUserRepository : IBaseRepositoryOperations<User, int>
    {
    }
}
