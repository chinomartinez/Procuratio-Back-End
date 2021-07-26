using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState
{
    internal class ValidateChangeStateOrder : IValidateChangeStateOrder
    {
        private readonly IOrderRepository _orderRepository;

        public ValidateChangeStateOrder(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void ValidateAndSetStateBeforeCreate(Domain.Entities.Order newEntity)
        {
            SetFromwithoutStateToWithoutOrdering(newEntity);
        }

        public async void ValidateAndSetStateBeforeUpdate(Domain.Entities.Order currentEntity)
        {
            Domain.Entities.Order entityInDatabase = await GetOrderAsync(currentEntity.ID);

            if (IsNewEntity(currentEntity.ID))
            {
                throw new InvalidOrderStateException("No se puede actualizar el estado de una entidad ya creada");
            }
            else if (currentEntity.OrderStateID == entityInDatabase.OrderStateID)
            {
                return;
            }
        }

        private void SetFromwithoutStateToWithoutOrdering(Domain.Entities.Order newEntity)
        {
            if (!IsNewEntity(newEntity.ID))
            {
                throw new InvalidOrderStateException("No se puede asignar de sin estado a en progreso, en una entidad ya creada");
            }

            newEntity.OrderStateID = (short)OrderState.State.WithoutOrdering;
        }

        private async Task<Domain.Entities.Order> GetOrderAsync(int id)
        {
            Domain.Entities.Order order = await _orderRepository.GetAsync(id);

            if (order is null)
            {
                throw new OrderNotFoundException();
            }

            return order;
        }

        private static bool IsNewEntity(int ID) => ID == 0;
    }
}
