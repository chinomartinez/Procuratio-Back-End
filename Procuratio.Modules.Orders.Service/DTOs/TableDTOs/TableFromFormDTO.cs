using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.TableDTOs
{
    public class TableFromFormDTO : IFromFormDTO
    {
        [Required]
        public int Capacity { get; set; }
    }
}
