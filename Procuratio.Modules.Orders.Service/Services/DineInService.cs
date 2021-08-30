using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using Procuratio.Shared.ProcuratioFramework.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal class DineInService : IDineInService
    {
        private readonly IDineInRepository _dinerInRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;
        private readonly IValidateChangeStateDineIn _validateChangeStateDineInState;
        private readonly IValidateChangeStateOrder _validateChangeStateOrder;

        public DineInService(IDineInRepository dinerInRepository, ITableRepository tableRepository, IMapper mapper,
            IValidateChangeStateDineIn validateChangeStateDineInState, IValidateChangeStateOrder validateChangeStateOrder)
        {
            _dinerInRepository = dinerInRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
            _validateChangeStateDineInState = validateChangeStateDineInState;
            _validateChangeStateOrder = validateChangeStateOrder;
        }

        public async Task<DineInDTO> GetAsync(int id)
        {
            DineIn dinerIn = await GetDineInAsync(id);

            return _mapper.Map<DineInDTO>(dinerIn);
        }

        public async Task<IReadOnlyList<DineInForListDTO>> BrowseAsync()
        {
            IReadOnlyList<DineIn> dinersIn = await _dinerInRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<DineInForListDTO>>(dinersIn);
        }

        public async Task UpdateAsync(DineInFromFormDTO dineInUpdateDTO, int id)
        {
            DineIn dineIn = await GetDineInAsync(id);

            dineIn = _mapper.Map(dineInUpdateDTO, dineIn);

            await _dinerInRepository.UpdateAsync(dineIn);
        }

        public async Task AddAsync(DineInFromFormDTO dineInCreationDTO)
        {
            DineIn dineIn = new();

            dineIn = _mapper.Map(dineInCreationDTO, dineIn);

            InitializeAndSetOrderToDineIn(dineIn);

            _validateChangeStateDineInState.ValidateAndSetStateBeforeCreate(dineIn);

            await _dinerInRepository.AddAsync(dineIn);
            await _tableRepository.SetTablesStateAsync(dineInCreationDTO.TablesIds, TableState.State.Ocuped);
        }

        public async Task DeleteAsync(int id)
        {
            DineIn dineIn = await GetDineInAsync(id);
            await _dinerInRepository.DeleteAsync(dineIn);
        }

        public async Task<DineInCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            DineInCreationFormInitializerDTO dineInCreationFormInitializerDTO = new DineInCreationFormInitializerDTO();

            List<Table> availablesTables = await _tableRepository.GetAvailablesTablesAsync();

            availablesTables.ForEach(x => dineInCreationFormInitializerDTO.Tables.Add(new SelectListItemDTO<int>() { ID = x.ID, Description = $"Numero {x.Number}" }));

            return dineInCreationFormInitializerDTO;
        }

        public async Task<DineInEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
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

        private void InitializeAndSetOrderToDineIn(DineIn newDineIn)
        {
            Domain.Entities.Order order = new();

            _validateChangeStateOrder.ValidateAndSetStateBeforeCreate(order);

            order.WaiterID = TGRID.UserID;
            order.CustomerID = TGRID.CustomerID;
            order.Date = DateTime.Now;

            newDineIn.Order = order;
        }
    }
}
