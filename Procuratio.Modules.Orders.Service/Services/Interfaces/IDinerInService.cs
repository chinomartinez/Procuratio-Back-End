using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services.Interfaces
{
    public interface IDinerInService
    {
        Task<ActionResult<DinerInDetailsDTO>> GetAsync(int id);
    }
}
