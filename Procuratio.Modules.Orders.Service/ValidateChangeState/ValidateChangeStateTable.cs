using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.ValidateChangeState
{
    internal class ValidateChangeStateTable : IValidateChangeStateTable
    {
        private readonly ITableRepository _tableRepository;

        public ValidateChangeStateTable(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public void ValidateAndSetStateBeforeCreate(Table newEntity)
        {
            SetFromwithoutStateToAvailable(newEntity);
        }

        public async void ValidateAndSetStateBeforeUpdate(Table currentEntity)
        {
            Table entityInDatabase = await GetTableAsync(currentEntity.ID);

            if (IsNewEntity(currentEntity.ID))
            {
                throw new InvalidOrderStateException("No se puede actualizar el estado de una entidad ya creada");
            }
            else if (currentEntity.TableStateID == entityInDatabase.TableStateID)
            {
                return;
            }
        }

        private void SetFromwithoutStateToAvailable(Table newEntity)
        {
            if (!IsNewEntity(newEntity.ID))
            {
                throw new InvalidOrderStateException("No se puede asignar de sin estado a en progreso, en una entidad ya creada");
            }

            newEntity.TableStateID = (short)TableState.State.Available;
        }

        private async Task<Table> GetTableAsync(int id)
        {
            Table table = await _tableRepository.GetAsync(id);

            if (table is null)
            {
                throw new TableNotFoundException();
            }

            return table;
        }

        private static bool IsNewEntity(int ID) => ID == 0;
    }
}
