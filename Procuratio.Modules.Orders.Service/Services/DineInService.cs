using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.DTOs.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.ValidateChangeState;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal class DineInService : IDineInService
    {
        private readonly IDineInRepository _dinerInRepository;
        private readonly IMapper _mapper;
        private readonly IValidateChangeStateDineIn _validateChangeStateDineInState;
        private readonly IValidateChangeStateOrder _validateChangeStateOrder;

        public DineInService(IDineInRepository dinerInRepository, IMapper mapper, 
            IValidateChangeStateDineIn validateChangeStateDineInState, IValidateChangeStateOrder validateChangeStateOrder)
        {
            _dinerInRepository = dinerInRepository;
            _mapper = mapper;
            _validateChangeStateDineInState = validateChangeStateDineInState;
            _validateChangeStateOrder = validateChangeStateOrder;
        }

        public async Task<DineInDTO> GetAsync(int id)
        {
            DineIn dinerIn = await GetDineInAsync(id);

            return _mapper.Map<DineInDTO>(dinerIn);
        }

        public async Task<IReadOnlyList<DineInDTO>> BrowseAsync()
        {
            IReadOnlyList<DineIn> DinersIn = await _dinerInRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<DineInDTO>>(DinersIn);
        }

        public async Task UpdateAsync(UpdateDineInDTO dineInUpdateDTO)
        {
            DineIn dineIn = await GetDineInAsync(dineInUpdateDTO.ID);

            dineIn = _mapper.Map(dineInUpdateDTO, dineIn);

            await _dinerInRepository.UpdateAsync(dineIn);
        }

        public async Task AddAsync(AddDineInDTO dineInCreationDTO)
        {
            Order order = new();

            _validateChangeStateOrder.SetFromwithoutStateToWithoutOrdering(order);

            DineIn dineIn = new()
            {
                Order = order
            };

            dineIn = _mapper.Map(dineInCreationDTO, dineIn);

            _validateChangeStateDineInState.SetFromWithoutStateToInProgress(dineIn);

            await _dinerInRepository.AddAsync(dineIn);
        }

        public async Task DeleteAsync(int id)
        {
            DineIn dineIn = await GetDineInAsync(id);
            await _dinerInRepository.DeleteAsync(dineIn);
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
    }
}
