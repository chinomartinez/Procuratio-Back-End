using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemCategoryDTOs;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services
{
    internal class ItemCategoryService : IItemCategoryService
    {
        private readonly IItemCategoryRepository _itemCategoryRepository;
        private readonly IMapper _mapper;

        public ItemCategoryService(IItemCategoryRepository itemCategoryRepository, IMapper mapper)
        {
            _itemCategoryRepository = itemCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ItemCategoryFromFormDTO addDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<ItemCategoryForListDTO>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemCategoryDTO> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemCategoryCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemCategoryEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(ItemCategoryFromFormDTO updateDTO, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
