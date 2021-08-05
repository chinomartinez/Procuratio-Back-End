using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface IDineInService : IBaseServiceOperations<DineInDTO, DineInListDTO, DineInFromFormDTO, DineInCreationFormInitializerDTO, DineInEditionFormInitializerDTO, int>
    {
    }
}
