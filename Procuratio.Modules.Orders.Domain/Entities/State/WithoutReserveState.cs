using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class WithoutReserveState : StateBaseEntity<WithoutReserve>
    {
        public enum State : short
        {
            Completed = 1,
            InProgress
        }
    }
}
