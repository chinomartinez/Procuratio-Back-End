using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations
{
    /// <summary>
    /// To be implemented at each concrete interface of each repository, provide bases method
    /// </summary>
    /// <typeparam name="T">Entity to delete</typeparam>
    public interface IBaseRepositoryOperations<T> where T : class
    {
        Task<T> GetAsync(int id);

        Task<IReadOnlyList<T>> BrowseAsync();

        Task UpdateAsync(T toUpdate);

        Task AddAsync(T toAdd);

        Task DeleteAsync(T entity);
    }
}
