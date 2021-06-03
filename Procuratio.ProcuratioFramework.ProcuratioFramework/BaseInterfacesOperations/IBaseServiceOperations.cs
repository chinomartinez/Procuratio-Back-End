using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations
{
    /// <summary>
    /// To be implemented at each concrete interface of each service, provide bases method
    /// </summary>
    /// <typeparam name="T">Base DTO of the entity</typeparam>
    /// <typeparam name="TUpdate">Update DTO of the entity</typeparam>
    /// <typeparam name="TAdd">Add DTO of the entity</typeparam>
    public interface IBaseServiceOperations<T, TUpdate, TAdd> 
        where T : class 
        where TUpdate : class 
        where TAdd : class
    {
        Task<T> GetAsync(int id);

        Task<IReadOnlyList<T>> BrowseAsync();

        Task UpdateAsync(TUpdate updateDTO);

        Task AddAsync(TAdd addDTO);

        Task DeleteAsync(int id);
    }
}
