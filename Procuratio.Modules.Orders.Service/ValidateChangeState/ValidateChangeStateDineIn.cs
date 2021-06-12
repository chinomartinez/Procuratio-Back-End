using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState
{
    internal class ValidateChangeStateDineIn : IValidateChangeStateDineIn
    {
        private readonly IDineInRepository _dinerInRepository;

        public ValidateChangeStateDineIn(IDineInRepository dinerInRepository)
        {
            _dinerInRepository = dinerInRepository;
        }

        public void ValidateAndSetStateBeforeCreate(DineIn newEntity)
        {
            SetFromWithoutStateToInProgress(newEntity);
        }

        public async void ValidateAndSetStateBeforeUpdate(DineIn currentEntity)
        {
            DineIn entityInDatabase = await GetDineInAsync(currentEntity.ID);

            if (IsNewEntity(currentEntity.ID)) 
            {
                throw new InvalidDineInStateException("No se puede actualizar el estado de una entidad ya creada");
            }
            else if (currentEntity.DinerInStateID == entityInDatabase.DinerInStateID)
            {
                return;
            }
        }

        private void SetFromWithoutStateToInProgress(DineIn newEntity)
        {
            if (!IsNewEntity(newEntity.ID))
            {
                throw new InvalidDineInStateException("No se puede asignar de sin estado a en progreso, en una entidad ya creada");
            }

            newEntity.DinerInStateID = (short)DineInState.State.InProgress;
        }

        private async Task<DineIn> GetDineInAsync(int id)
        {
            DineIn dineIn = await _dinerInRepository.GetAsync(id);

            if (dineIn is null)
            {
                throw new DineInNotFoundException();
            }

            return dineIn;
        }

        private static bool IsNewEntity(int ID) => ID == 0;
    }
}
