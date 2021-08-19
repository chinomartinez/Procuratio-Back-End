using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Order.Service.DTOs.TableDTOs;
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

        public async Task AddAsync([FromForm] TableFromFormDTO createDTO)
        {
            Table newTable = new();

            newTable = _mapper.Map(createDTO, newTable);

            newTable.Number = await GetNextTableNumber();

            _validateChangeStateTable.ValidateAndSetStateBeforeCreate(newTable);

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

        public async Task UpdateAsync([FromForm] TableFromFormDTO updateDTO, int ID)
        {
            Table table = await GetTableAsync(ID);

            table = _mapper.Map(updateDTO, table);

            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteAsync(int ID)
        {
            Table table = await GetTableAsync(ID);
            await _tableRepository.DeleteAsync(table);
        }

        public async Task<TableCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            TableCreationFormInitializerDTO tableCreationFormInitializerDTO = new TableCreationFormInitializerDTO();

            tableCreationFormInitializerDTO.NextTableNumber = await GetNextTableNumber();

            return tableCreationFormInitializerDTO;
        }

        public async Task<TableEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int ID)
        {
            Table table = await _tableRepository.GetEntityEditionFormInitializerAsync(ID);

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
