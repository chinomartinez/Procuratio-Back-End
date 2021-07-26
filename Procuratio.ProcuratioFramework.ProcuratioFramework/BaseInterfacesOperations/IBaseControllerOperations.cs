using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations
{
    /// <summary>
    /// To be implemented at each concrete interface of each controller, provide bases method
    /// </summary>
    /// <typeparam name="T">Base DTO of the entity</typeparam>
    /// <typeparam name="TForListDTO">DTO of the entity for load </typeparam>
    /// <typeparam name="TUpdate">Update DTO of the entity</typeparam>
    /// <typeparam name="TAdd">Create DTO of the entity</typeparam>
    /// <typeparam name="TKey">Type of key of the entity</typeparam>
    public interface IBaseControllerOperations<T, TForListDTO, TUpdate, TAdd, TKey>
        where T : IDTO
        where TForListDTO : IForListDTO
        where TUpdate : IUpdateDTO
        where TAdd : IAddDTO
    {
        Task<ActionResult<T>> GetAsync(TKey id);

        Task<ActionResult> AddAsync([FromBody] TAdd addDTO);

        Task<ActionResult<IReadOnlyList<TForListDTO>>> BrowseAsync();

        Task UpdateAsync([FromBody] TUpdate updateDTO);

        Task<ActionResult> DeleteAsync(TKey id);
    }
}
