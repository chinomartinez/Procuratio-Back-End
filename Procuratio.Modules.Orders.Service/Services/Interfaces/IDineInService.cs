using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.DTOs.DinerInDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface IDineInService : IBaseServiceOperations<DineInDTO, UpdateDineInDTO, AddDineInDTO, int>
    {
    }
}
