using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableForListDTO : IListDTO
    {
        public int ID { get; set; }

        public short Number { get; set; }

        public int Capacity { get; set; }

        public short TableStateID { get; set; }

        public string StateName { get; set; }
    }
}
