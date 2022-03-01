using AutoMapper;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using Procuratio.Modules.Restaurant.Service.Exceptions;
using Procuratio.Modules.Restaurant.Service.Service.Interfaces;
using Procuratio.Modules.Restaurants.Domain.Entities;
using Procuratio.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Service
{
    internal class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<bool> ExistBranchId(int branchId)
        {
            return await _branchRepository.ExistBranchId(branchId);
        }

        public async Task<bool> GetAllowOnlineMenu(int branchId)
        {
            return await _branchRepository.GetAllowOnlineMenu(branchId);
        }

        public async Task<bool> GetAllowOrderFromTable(string orderKey)
        {
            Regex regex = new("([1-9][0-9]*|0)-([1-9][0-9]*|0)");

            if (!regex.IsMatch(orderKey)) { throw new InvalidOrderKeyException(); }

            string[] values = orderKey.Split('-');

            return await _branchRepository.GetAllowOrderFromTable(Convert.ToInt32(values[1]));
        }

        public async Task<BranchForMenuDTO> GetBranchForMenu(int branchId)
        {
            BranchForMenuModel branchForMenuModel = await _branchRepository.GetBranchForMenu(branchId);

            return _mapper.Map<BranchForMenuDTO>(branchForMenuModel);
        }

        public async Task<List<RestaurantForOnlineMenuDTO>> GetRestaurantsForOnlineMenu()
        {
            List<RestaurantForOnlineMenuModel> restaurantModel = await _branchRepository.GetRestaurantsForOnlineMenu();

            return _mapper.Map<List<RestaurantForOnlineMenuDTO>>(restaurantModel);
        }

        public async Task<List<SettingsDTO>> GetSettings(int branchId)
        {
            List<SettingsModel> settingsModels = await _branchRepository.GetSettings(branchId);

            return _mapper.Map<List<SettingsDTO>>(settingsModels);
        }

        public async Task UpdateSettings(SettingsFromFormDTO settingsFromFormDTO, int branchId)
        {
            Branch branch = await _branchRepository.GetBranchForUpdateSettings(branchId);

            if (branch == null) { throw new BranchNotFoundException(); }

            branch = _mapper.Map(settingsFromFormDTO, branch);

            await _branchRepository.UpdateSettings(branch);
        }
    }
}
