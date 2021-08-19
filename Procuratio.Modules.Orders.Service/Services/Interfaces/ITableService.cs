using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface ITableService : IBaseServiceOperations<TableDTO, TableForListDTO, TableFromFormDTO, TableCreationFormInitializerDTO, TableEditionFormInitializerDTO, int> { }
}
