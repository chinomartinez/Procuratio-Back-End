using AutoMapper;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using Procuratio.Modules.Restaurant.Service.Service.Interfaces;
using System.Collections.Generic;
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

        public async Task<BranchForMenuDTO> GetBranchForMenu(int branchId)
        {
            BranchForMenuModel branchForMenuModel = await _branchRepository.GetBranchForMenu(branchId);

            return _mapper.Map<BranchForMenuDTO>(branchForMenuModel);
        }

        public async Task<List<SettingsDTO>> GetSettings(int branchId)
        {
            List<SettingsModel> settingsModels = await _branchRepository.GetSettings(branchId);

            return _mapper.Map<List<SettingsDTO>>(settingsModels);
        }
    }
}
