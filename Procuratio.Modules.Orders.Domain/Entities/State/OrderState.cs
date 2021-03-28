using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class OrderState : StateBaseEntity<int>
    {
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }
}
