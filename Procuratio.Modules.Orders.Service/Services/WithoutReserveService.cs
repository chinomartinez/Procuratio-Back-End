using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.Modules.Orders.Service.Exceptions;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Services
{
    internal class WithoutReserveService : IWithoutReserveService
    {
        private readonly IWithoutReserveRepository _withoutReserveRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public WithoutReserveService(IWithoutReserveRepository withoutReserveRepository, ITableRepository tableRepository, IMapper mapper)
        {
            _withoutReserveRepository = withoutReserveRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<WithoutReserveDTO> GetAsync(int id)
        {
            WithoutReserve withoutReserve = await GetWithoutReserveAsync(id);

            return _mapper.Map<WithoutReserveDTO>(withoutReserve);
        }

        public async Task<IReadOnlyList<WithoutReserveForListDTO>> BrowseAsync()
        {
            IReadOnlyList<WithoutReserve> withoutReserves = await _withoutReserveRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<WithoutReserveForListDTO>>(withoutReserves);
        }

        public async Task UpdateAsync(WithoutReserveFromFormDTO withoutReserveUpdateDTO, int id)
        {
            WithoutReserve withoutReserveToUpdate = await _withoutReserveRepository.GetWithTableXWithoutReserveAsync(id);

            if (withoutReserveToUpdate is null) { throw new WithoutReserveNotFoundException(); }

            withoutReserveToUpdate.TableXWithoutReserve.Clear();

            withoutReserveToUpdate = _mapper.Map(withoutReserveUpdateDTO, withoutReserveToUpdate);

            await _withoutReserveRepository.UpdateAsync(withoutReserveToUpdate);
        }

        public async Task AddAsync(WithoutReserveFromFormDTO withoutReserveCreationDTO)
        {
            WithoutReserve withoutReserve = new();
            withoutReserve.WithoutReserveStateId = (short)WithoutReserveState.State.InProgress;

            withoutReserve = _mapper.Map(withoutReserveCreationDTO, withoutReserve);

            InitializeAndSetOrderToWithoutReserve(withoutReserve);

            await _withoutReserveRepository.AddAsync(withoutReserve);
        }

        public async Task DeleteAsync(int id)
        {
            WithoutReserve withoutReserve = await GetWithoutReserveAsync(id);
            await _withoutReserveRepository.DeleteAsync(withoutReserve);
        }

        public async Task<WithoutReserveCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            WithoutReserveCreationFormInitializerDTO withoutReserveCreationFormInitializerDTO = new WithoutReserveCreationFormInitializerDTO();

            List<Table> availablesTables = await _tableRepository.GetAvailablesTablesAsync();

            availablesTables.ForEach(x => withoutReserveCreationFormInitializerDTO.Tables.Add(new SelectListItemDTO() { Id = x.Id.ToString(), Description = x.Number.ToString() }));

            return withoutReserveCreationFormInitializerDTO;
        }

        public async Task<WithoutReserveEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            WithoutReserveEditionFormInitializerDTO withoutReserveEditionFormInitializerDTO = new();

            WithoutReserve withoutReserveToEdit = await _withoutReserveRepository.GetEntityEditionFormInitializerAsync(id);

            if (withoutReserveToEdit is null) { throw new WithoutReserveNotFoundException(); }

            List<Table> availablesTables = await _tableRepository.GetAvailablesTablesAsync();

            withoutReserveEditionFormInitializerDTO = _mapper.Map<WithoutReserveEditionFormInitializerDTO>(withoutReserveToEdit, opt =>
            {
                opt.AfterMap((src, dest) => availablesTables.ForEach(x => dest.Tables.Items.Add(new SelectListItemDTO() { Id = x.Id.ToString(), Description = x.Number.ToString() })));
            });

            return withoutReserveEditionFormInitializerDTO;
        }

        public async Task<IReadOnlyList<WithoutReserveInProgressDTO>> GetInProgressAsync()
        {
            IReadOnlyList<WithoutReserve> withoutReserves = await _withoutReserveRepository.GetInProgressAsync();

            return _mapper.Map<IReadOnlyList<WithoutReserveInProgressDTO>>(withoutReserves);
        }

        private async Task<WithoutReserve> GetWithoutReserveAsync(int id)
        {
            WithoutReserve withoutReserve = await _withoutReserveRepository.GetAsync(id);

            if (withoutReserve is null) { throw new WithoutReserveNotFoundException(); }

            return withoutReserve;
        }

        private static void InitializeAndSetOrderToWithoutReserve(WithoutReserve newWithoutReserve)
        {
            Domain.Entities.Order order = new();

            order.OrderStateId = (short)OrderState.State.Pending;
            order.WaiterId = TGRID.UserId;
            order.CustomerId = TGRID.CustomerId;
            order.Date = DateTime.Now;

            newWithoutReserve.Order = order;
        }
    }
}
