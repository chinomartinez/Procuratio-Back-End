using Microsoft.AspNetCore.Identity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity
{
    public interface IUserRepository : IBaseRepositoryOperations<User, int>
    {
        Task<SignInResult> Loginasync(string userName, string password);
    }
}
