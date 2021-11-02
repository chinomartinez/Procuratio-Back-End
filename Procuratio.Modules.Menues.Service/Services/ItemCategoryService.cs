using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemCategoryDTOs;
using Procuratio.Modules.Menu.Service.Exceptions;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
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
            ItemCategory itemCategory = new();

            itemCategory = _mapper.Map(addDTO, itemCategory);

            itemCategory.ItemCategoryStateId = (short)ItemCategoryState.State.Available;

            await _itemCategoryRepository.AddAsync(itemCategory);
        }

        public async Task<IReadOnlyList<ItemCategoryForListDTO>> BrowseAsync()
        {
            IReadOnlyList<ItemCategory> itemCategories = await _itemCategoryRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<ItemCategoryForListDTO>>(itemCategories);
        }

        public async Task DeleteAsync(int id)
        {
            ItemCategory table = await GetItemCategoryAsync(id);
            await _itemCategoryRepository.DeleteAsync(table);
        }

        public async Task<ItemCategoryDTO> GetAsync(int id)
        {
            ItemCategory itemCategory = await GetItemCategoryAsync(id);

            return _mapper.Map<ItemCategoryDTO>(itemCategory);
        }

        public async Task<ItemCategoryCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            ItemCategoryCreationFormInitializerDTO itemCategoryCreationFormInitializerDTO = new();

            return itemCategoryCreationFormInitializerDTO;
        }

        public async Task<ItemCategoryEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            ItemCategory itemCategory = await _itemCategoryRepository.GetEntityEditionFormInitializerAsync(id);

            return _mapper.Map<ItemCategoryEditionFormInitializerDTO>(itemCategory);
        }

        public async Task UpdateAsync(ItemCategoryFromFormDTO updateDTO, int id)
        {
            ItemCategory itemCategory = await GetItemCategoryAsync(id);

            itemCategory = _mapper.Map(updateDTO, itemCategory);

            await _itemCategoryRepository.UpdateAsync(itemCategory);
        }

        private async Task<ItemCategory> GetItemCategoryAsync(int id)
        {
            ItemCategory itemCategory = await _itemCategoryRepository.GetAsync(id);

            if (itemCategory is null) { throw new ItemCategoryNotFoundException(); }

            return itemCategory;
        }
    }
}
