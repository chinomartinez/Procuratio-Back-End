using AutoMapper;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;
        private readonly IValidateChangeStateTable _validateChangeStateTable;

        public TableService(ITableRepository tableRepository, IMapper mapper, IValidateChangeStateTable validateChangeStateTable)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
            _validateChangeStateTable = validateChangeStateTable;
        }

        public async Task AddAsync(AddTableDTO createDTO)
        {
            Table newTable = new();

            newTable = _mapper.Map(createDTO, newTable);

            short? lastNumber = await GetLastNumberAsync();

            if (lastNumber == null)
            {
                const short numberIfIsFirstTable = 1;

                newTable.Number = numberIfIsFirstTable;
            }
            else
            {
                newTable.Number = (short)(lastNumber + 1);
            }

            _validateChangeStateTable.SetFromwithoutStateToAvailable(newTable);

            await _tableRepository.AddAsync(newTable);
        }

        private async Task<short?> GetLastNumberAsync()
        {
            return await Task.FromResult(_tableRepository.GetLastNumberAsync().Result);
        }

        public async Task<IReadOnlyList<TableDTO>> BrowseAsync()
        {
            IReadOnlyList<Table> tables = await _tableRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<TableDTO>>(tables);
        }

        public async Task<TableDTO> GetAsync(int id)
        {
            Table table = await GetTableAsync(id);

            return _mapper.Map<TableDTO>(table);
        }

        public async Task UpdateAsync(UpdateTableDTO updateDTO)
        {
            Table table = await GetTableAsync(updateDTO.ID);

            table = _mapper.Map(updateDTO, table);

            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteAsync(int id)
        {
            Table table = await GetTableAsync(id);
            await _tableRepository.DeleteAsync(table);
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
    }
}
