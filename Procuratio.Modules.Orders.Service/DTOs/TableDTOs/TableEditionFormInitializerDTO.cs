using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableEditionFormInitializerDTO : IEntityEditionFormInitializerDTO
    {
        public TableDTO Table { get; set; }

        public string StateName { get; set; }
    }
}
