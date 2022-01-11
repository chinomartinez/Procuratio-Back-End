using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menu.Service.Exceptions;
using Procuratio.Modules.Menu.Shared.DTO;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services
{
    internal class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly IMenuSubcategoryRepository _menuSubcategoryRepository;

        public ItemService(IItemRepository itemRepository, IMapper mapper, IMenuSubcategoryRepository menuSubcategoryRepository)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _menuSubcategoryRepository = menuSubcategoryRepository;
        }

        public async Task AddAsync(ItemFromFormDTO addDTO)
        {
            Item item = new();

            int nextOrder = await _itemRepository.GetNextOrderAsync((int)addDTO.MenuSubcategoryId);

            item = _mapper.Map(addDTO, item, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.ItemStateId = (short)ItemState.State.Available;
                    dest.Order = nextOrder;
                });
            });

            await _itemRepository.AddAsync(item);
        }

        public async Task<IReadOnlyList<ItemForListDTO>> BrowseAsync()
        {
            IReadOnlyList<Item> items = await _itemRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<ItemForListDTO>>(items);
        }

        public async Task DeleteAsync(int id)
        {
            Item item = await GetItemAsync(id);
            await _itemRepository.DeleteAsync(item);
        }

        public async Task<ItemDTO> GetAsync(int id)
        {
            Item item = await GetItemAsync(id);

            return _mapper.Map<ItemDTO>(item);
        }

        public async Task<ItemCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            ItemCreationFormInitializerDTO itemCreationFormInitializerDTO = new();

            List<MenuSubcategory> menuSubcategories = await _menuSubcategoryRepository.GetAllAsync();

            menuSubcategories.ForEach(x => itemCreationFormInitializerDTO.MenuSubcategories.Add(new SelectListItemDTO() { Id = x.Id.ToString(), Description = x.Name }));

            return itemCreationFormInitializerDTO;
        }

        public async Task<ItemEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            Item item = await _itemRepository.GetEntityEditionFormInitializerAsync(id);

            return _mapper.Map<ItemEditionFormInitializerDTO>(item);
        }

        public async Task UpdateAsync(ItemFromFormDTO updateDTO, int id)
        {
            Item item = await GetItemAsync(id);

            updateDTO.MenuSubcategoryId = item.MenuSubcategoryId;

            item = _mapper.Map(updateDTO, item);

            await _itemRepository.UpdateAsync(item);
        }

        public async Task<List<ItemDTO>> GetByIds(List<int> ids)
        {
            List<Item> items = await _itemRepository.GetByIdsAsync(ids);

            return _mapper.Map<List<ItemDTO>>(items);
        }

        public async Task<IReadOnlyList<MenuAddItemsToOrderVM>> GetMenuAddItemsToOrderAsync()
        {
            IReadOnlyList<Item> items = await _itemRepository.GetMenuAddItemsToOrderAsync();

            return _mapper.Map<IReadOnlyList<MenuAddItemsToOrderVM>>(items);
        }

        public async Task<List<MenuForOrderDetailDTO>> GetMenuForOrderDetailAsync(List<int> itemIds, bool dineIn)
        {
            List<MenuForOrderDetail> menuForOrderDetailList = await _itemRepository.GetMenuForOrderDetailAsync(itemIds, dineIn);

            return _mapper.Map<List<MenuForOrderDetailDTO>>(menuForOrderDetailList);
        }

        public async Task<List<ItemsForOrderDetailInKitchenDTO>> GetItemsForKitchenAsync(List<int> itemIds)
        {
            List<ItemsForOrderDetailInKitchen> itemsForOrderDetailInKitchenList = await _itemRepository.GetItemsForKitchenAsync(itemIds);

            return _mapper.Map<List<ItemsForOrderDetailInKitchenDTO>>(itemsForOrderDetailInKitchenList);
        }

        public async Task<List<ItemsForBillDTO>> GetItemsFoBillAsync(List<int> itemIds, bool dineIn)
        {
            List<ItemsBill> itemsForBillList = await _itemRepository.GetItemsFoBillAsync(itemIds, dineIn);

            return _mapper.Map<List<ItemsForBillDTO>>(itemsForBillList);
        }

        private async Task<Item> GetItemAsync(int id)
        {
            Item item = await _itemRepository.GetAsync(id);

            if (item is null) { throw new ItemNotFoundException(); }

            return item;
        }
    }
}
