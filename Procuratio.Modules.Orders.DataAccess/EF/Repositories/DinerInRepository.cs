using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Repositories
{
    internal class DinerInRepository : IDinerInRepository
    {
        private readonly OrdersDbContext _ordersDbContext;

        public DinerInRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Task<DinerIn> GetAsync(int id)
        {
            return Task.FromResult(_ordersDbContext.DinerIn.SingleOrDefault(x => x.ID == id));
        }
    }
}
