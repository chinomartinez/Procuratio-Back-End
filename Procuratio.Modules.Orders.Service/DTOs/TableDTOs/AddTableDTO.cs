using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class AddTableDTO
    {
        [Required]
        public int Capacity { get; set; }
    }
}
