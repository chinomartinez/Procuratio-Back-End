using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface ITableService : IBaseServiceOperations<TableDTO, TableForListDTO, TableFromFormDTO, TableCreationFormInitializerDTO, TableEditionFormInitializerDTO, int> { }
}
