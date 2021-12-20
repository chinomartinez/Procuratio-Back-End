using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface IWithoutReserveService : IBaseServiceOperations<WithoutReserveDTO, WithoutReserveForListDTO, WithoutReserveFromFormDTO, WithoutReserveCreationFormInitializerDTO, WithoutReserveEditionFormInitializerDTO, int>
    {
    }
}
