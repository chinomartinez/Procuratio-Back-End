﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Order.Service.DTOs.OrderDTOs;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.DTOs.TableDTOs;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using Procuratio.Shared.ProcuratioFramework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal class DineInService : IDineInService
    {
        private readonly IDineInRepository _dinerInRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public DineInService(IDineInRepository dinerInRepository, ITableRepository tableRepository, IMapper mapper)
        {
            _dinerInRepository = dinerInRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
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
            DineIn dineInToUpdate = await _dinerInRepository.GetWithTableXDinerInAsync(id);

            if (dineInToUpdate is null) { throw new DineInNotFoundException(); }

            dineInToUpdate.TableXDinerIn.Clear();

            dineInToUpdate = _mapper.Map(dineInUpdateDTO, dineInToUpdate);

            await _dinerInRepository.UpdateAsync(dineInToUpdate);
        }

        public async Task AddAsync(DineInFromFormDTO dineInCreationDTO)
        {
            DineIn dineIn = new();
            dineIn.DinerInStateID = (short)DineInState.State.InProgress;

            dineIn = _mapper.Map(dineInCreationDTO, dineIn);

            InitializeAndSetOrderToDineIn(dineIn);

            await _dinerInRepository.AddAsync(dineIn);
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

            availablesTables.ForEach(x => dineInCreationFormInitializerDTO.Tables.Add(new SelectListItemDTO<int>() { ID = x.ID, Description = x.Number.ToString() }));

            return dineInCreationFormInitializerDTO;
        }

        public async Task<DineInEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            DineInEditionFormInitializerDTO dineInEditionFormInitializerDTO = new();

            DineIn dineInToEdit = await _dinerInRepository.GetEntityEditionFormInitializerAsync(id);

            if (dineInToEdit is null) { throw new DineInNotFoundException(); }

            List<Table> availablesTables = await _tableRepository.GetAvailablesTablesAsync();

            dineInEditionFormInitializerDTO = _mapper.Map<DineInEditionFormInitializerDTO>(dineInToEdit, opt => 
            {
                opt.AfterMap((src, dest) => availablesTables.ForEach(x => dest.Tables.Items.Add(new SelectListItemDTO<int>() { ID = x.ID, Description = x.Number.ToString() })));
            });

            return dineInEditionFormInitializerDTO;
        }

        public async Task<IReadOnlyList<DineInInProgressDTO>> GetDineInInProgressAsync()
        {
            IReadOnlyList<DineIn> dinesIn = await _dinerInRepository.GetDineInInProgressAsync();

            return _mapper.Map<IReadOnlyList<DineInInProgressDTO>>(dinesIn);
        }

        private async Task<DineIn> GetDineInAsync(int id)
        {
            DineIn dineIn = await _dinerInRepository.GetAsync(id);

            if (dineIn is null) { throw new DineInNotFoundException(); }

            return dineIn;
        }

        private static void InitializeAndSetOrderToDineIn(DineIn newDineIn)
        {
            Domain.Entities.Order order = new();

            order.OrderStateID = (short)OrderState.State.Pending;
            order.WaiterID = TGRID.UserID;
            order.CustomerID = TGRID.CustomerID;
            order.Date = DateTime.Now;

            newDineIn.Order = order;
        }
    }
}
