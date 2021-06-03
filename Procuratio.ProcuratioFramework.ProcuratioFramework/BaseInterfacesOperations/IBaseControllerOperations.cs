using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations
{
    /// <summary>
    /// To be implemented at each concrete interface of each controller, provide bases method
    /// </summary>
    /// <typeparam name="T">Base DTO of the entity</typeparam>
    /// <typeparam name="TUpdate">Update DTO of the entity</typeparam>
    /// <typeparam name="TCreate">Create DTO of the entity</typeparam>
    public interface IBaseControllerOperations<T, TUpdate, TCreate>
        where T : class
        where TUpdate : class
        where TCreate : class
    {
        Task<ActionResult<T>> GetAsync(int id);

        Task<ActionResult> AddAsync([FromBody] TCreate addDTO);

        Task<ActionResult<IReadOnlyList<T>>> BrowseAsync();

        Task UpdateAsync([FromBody] TUpdate updateDTO);

        Task<ActionResult> DeleteAsync(int id);
    }
}
