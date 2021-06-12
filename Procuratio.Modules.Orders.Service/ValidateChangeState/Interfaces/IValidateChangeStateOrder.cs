using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ValidateChangeStateBase;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces
{
    internal interface IValidateChangeStateOrder : IValidateChangeStateBase<Order>
    {
    }
}
