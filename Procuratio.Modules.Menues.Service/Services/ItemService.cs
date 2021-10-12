using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services
{
    internal class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public ItemService()
        {

        }

        public async Task AddAsync(ItemFromFormDTO addDTO)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<ItemForListDTO>> BrowseAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemDTO> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ItemEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(ItemFromFormDTO updateDTO, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<MenuDTO>> GetMenuAsync()
        {
            IReadOnlyList<Item> items = await _itemRepository.GetMenuAsync();

            return _mapper.Map<IReadOnlyList<MenuDTO>>(items);
        }

        public async Task<List<ItemDTO>> GetByIds(List<int> ids)
        {
            List<Item> items = await _itemRepository.GetByIdsAsync(ids);

            return _mapper.Map<List<ItemDTO>>(items);
        }
    }
}
