using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations
{
    /// <summary>
    /// To be implemented at each concrete interface of each repository, provide bases method
    /// </summary>
    /// <typeparam name="T">Entity to delete</typeparam>
    /// <typeparam name="TKey">Type of key of the entity</typeparam>
    public interface IBaseRepositoryOperations<T, TKey> where T : class
    {
        Task<T> GetAsync(TKey id);

        Task<IReadOnlyList<T>> BrowseAsync();

        Task UpdateAsync(T toUpdate);

        Task AddAsync(T toAdd);

        Task DeleteAsync(T entity);
    }
}
