﻿using Microsoft.AspNetCore.Mvc;
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
    /// <typeparam name="TEntityCreationFormInitializerDTO">DTO for inicializing a creation entity form</typeparam>
    /// <typeparam name="TEntityEditionFormInitializerDTO">DTO for inicializing a edit entity form</typeparam>
    /// <typeparam name="TKey">Type of key of the entity</typeparam>
    public interface IBaseControllerOperations<T, TListDTO, TFromFormDTO, TEntityCreationFormInitializerDTO, TEntityEditionFormInitializerDTO, TKey>
        where T : IDTO
        where TListDTO : IListDTO
        where TFromFormDTO : IFromFormDTO
        where TEntityCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
        where TEntityEditionFormInitializerDTO : IEntityEditionFormInitializerDTO
    {
        Task<ActionResult<T>> GetAsync(TKey ID);

        Task<ActionResult> AddAsync([FromForm] TFromFormDTO addDTO);

        Task<ActionResult<IReadOnlyList<TListDTO>>> BrowseAsync();

        Task<ActionResult> UpdateAsync(TKey ID, [FromForm] TFromFormDTO updateDTO);

        Task<ActionResult> DeleteAsync(TKey ID);

        Task<ActionResult<TEntityCreationFormInitializerDTO>> GetEntityCreationFormInitializerAsync();

        Task<ActionResult<TEntityEditionFormInitializerDTO>> GetEntityEditionFormInitializerAsync(TKey ID);
    }
}