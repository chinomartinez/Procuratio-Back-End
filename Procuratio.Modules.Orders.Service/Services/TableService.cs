using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal sealed class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableService(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TableFromFormDTO createDTO)
        {
            Table newTable = new();

            newTable = _mapper.Map(createDTO, newTable);

            newTable.Number = await GetNextTableNumber();
            newTable.TableStateId = (short)TableState.State.Available;

            await _tableRepository.AddAsync(newTable);
        }

        public async Task<IReadOnlyList<TableForListDTO>> BrowseAsync()
        {
            IReadOnlyList<Table> tables = await _tableRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<TableForListDTO>>(tables);
        }

        public async Task<TableDTO> GetAsync(int id)
        {
            Table table = await GetTableAsync(id);

            return _mapper.Map<TableDTO>(table);
        }

        public async Task UpdateAsync(TableFromFormDTO updateDTO, int id)
        {
            Table table = await GetTableAsync(id);

            table = _mapper.Map(updateDTO, table);

            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteAsync(int id)
        {
            Table table = await GetTableAsync(id);
            await _tableRepository.DeleteAsync(table);
        }

        public async Task<TableCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            TableCreationFormInitializerDTO tableCreationFormInitializerDTO = new();

            tableCreationFormInitializerDTO.NextTableNumber = await GetNextTableNumber();

            return tableCreationFormInitializerDTO;
        }

        public async Task<TableEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            Table table = await _tableRepository.GetEntityEditionFormInitializerAsync(id);

            return _mapper.Map<TableEditionFormInitializerDTO>(table);
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

        private async Task<short> GetNextTableNumber()
        {
            short? lastNumber = await _tableRepository.GetLastNumberAsync();

            if (lastNumber == null)
            {
                const short numberIfItsFirstTable = 1;

                return numberIfItsFirstTable;
            }
            else
            {
                return (short)(lastNumber + 1);
            }
        }
    }
}
