using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DeliveryState : StateBaseEntity<Delivery>
    {
        public enum State : short
        {
            Completed = 1,
            InProgress
        }
    }
}
