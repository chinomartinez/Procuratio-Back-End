using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces
{
    public interface IDinerInRepository
    {
        Task<DinerIn> GetAsync(int id);
    }
}
