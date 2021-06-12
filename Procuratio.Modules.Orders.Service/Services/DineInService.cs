using AutoMapper;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using Procuratio.Modules.Orders.Service.DTOs.DinerInDTOs;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System.Collections.Generic;
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
            DineIn dineIn = new();

            dineIn = _mapper.Map(dineInCreationDTO, dineIn);

            SetOrderToDineIn(dineIn);

            _validateChangeStateDineInState.ValidateAndSetStateBeforeCreate(dineIn);

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

        private void SetOrderToDineIn(DineIn newDineIn)
        {
            Order order = new();

            _validateChangeStateOrder.ValidateAndSetStateBeforeCreate(order);

            newDineIn.Order = order;
        }
    }
}
