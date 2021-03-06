using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations
{
    /// <summary>
    /// To be implemented at each concrete interface of each service, provide bases method
    /// </summary>
    /// <typeparam name="T">Base DTO of the entity</typeparam>
    /// <typeparam name="TFromFormDTO">TFromFormDTO DTO of the entity for creation or updating</typeparam>
    /// <typeparam name="TEntityCreationFormInitializerDTO">DTO for inicializing a creation entity form</typeparam>
    /// <typeparam name="TEntityEditionFormInitializerDTO">DTO for inicializing a edit entity form</typeparam>
    /// <typeparam name="TKey">Type of key of the entity</typeparam>
    public interface IBaseServiceOperations<T, TListDTO, TFromFormDTO, TEntityCreationFormInitializerDTO, TEntityEditionFormInitializerDTO, TKey>
        where T : class, IDTO
        where TListDTO : class, IListDTO<T>
        where TFromFormDTO : class, IFromFormDTO
        where TEntityCreationFormInitializerDTO : class, IEntityCreationFormInitializerDTO
        where TEntityEditionFormInitializerDTO : class, IEntityEditionFormInitializerDTO<T>
    {
        Task<T> GetAsync(TKey id);

        Task<IReadOnlyList<TListDTO>> BrowseAsync();

        Task UpdateAsync(TFromFormDTO updateDTO, TKey id);

        Task AddAsync(TFromFormDTO addDTO);

        Task DeleteAsync(TKey id);

        Task<TEntityCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync();

        Task<TEntityEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(TKey id);
    }
}
