using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface IDineInService : IBaseServiceOperations<DineInDTO, DineInForListDTO, DineInFromFormDTO, DineInCreationFormInitializerDTO, DineInEditionFormInitializerDTO, int>
    {
        Task<IReadOnlyList<DineInInProgressDTO>> GetDineInInProgressAsync();
    }
}
