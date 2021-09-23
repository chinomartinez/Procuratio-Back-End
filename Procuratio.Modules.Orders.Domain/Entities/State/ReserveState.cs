using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class ReserveState : StateBaseEntity<Reserve>
    {
        public enum State : short
        {
            Pending = 1,
            Unconfirmed,
            InProgress,
            Completed,
            DidNotCome
        }
    }
}
