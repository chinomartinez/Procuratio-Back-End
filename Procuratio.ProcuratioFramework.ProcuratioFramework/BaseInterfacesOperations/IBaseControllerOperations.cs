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
    /// <typeparam name="TListDTO">DTO of the entity for load </typeparam>
    /// <typeparam name="TFromFormDTO">TFromFormDTO DTO of the entity for creation or updating</typeparam>
    /// <typeparam name="TKey">Type of key of the entity</typeparam>
    public interface IBaseControllerOperations<T, TListDTO, TFromFormDTO, TEntityCreationFormInitializerDTO, TEntityEditionFormInitializerDTO, TKey>
        where T : IDTO
        where TListDTO : IListDTO
        where TFromFormDTO : IFromFormDTO
        where TEntityCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
        where TEntityEditionFormInitializerDTO : IEntityEditionFormInitializerDTO
    {
        Task<ActionResult<T>> GetAsync(TKey id);

        Task<ActionResult> AddAsync([FromBody] TFromFormDTO addDTO);

        Task<ActionResult<IReadOnlyList<TListDTO>>> BrowseAsync();

        Task UpdateAsync([FromBody] TFromFormDTO updateDTO, TKey ID);

        Task<ActionResult> DeleteAsync(TKey id);

        Task<ActionResult<TEntityCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync();

        Task<ActionResult<TEntityEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(TKey ID);
    }
}
