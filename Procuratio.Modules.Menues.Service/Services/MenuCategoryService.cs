using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs;
using Procuratio.Modules.Menu.Service.Exceptions;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services
{
    internal class MenuCategoryService : IMenuCategoryService
    {
        private readonly IMenuCategoryRepository _menuCategoryRepository;
        private readonly IMapper _mapper;

        public MenuCategoryService(IMenuCategoryRepository menuCategoryRepository, IMapper mapper)
        {
            _menuCategoryRepository = menuCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(MenuCategoryFromFormDTO addDTO)
        {
            MenuCategory menuCategory = new();

            int nextOrder = await _menuCategoryRepository.GetNextOrderAsync();

            menuCategory = _mapper.Map(addDTO, menuCategory, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.MenuCategoryStateId = (short)MenuCategoryState.State.Available;
                    dest.Order = nextOrder;
                });
            });

            await _menuCategoryRepository.AddAsync(menuCategory);
        }

        public async Task<IReadOnlyList<MenuCategoryForListDTO>> BrowseAsync()
        {
            IReadOnlyList<MenuCategory> menuCategories = await _menuCategoryRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<MenuCategoryForListDTO>>(menuCategories);
        }

        public async Task DeleteAsync(int id)
        {
            MenuCategory menuCategories = await GetMenuCategoryAsync(id);
            await _menuCategoryRepository.DeleteAsync(menuCategories);
        }

        public async Task<MenuCategoryDTO> GetAsync(int id)
        {
            MenuCategory menuCategory = await GetMenuCategoryAsync(id);

            return _mapper.Map<MenuCategoryDTO>(menuCategory);
        }

        public async Task<MenuCategoryCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            MenuCategoryCreationFormInitializerDTO menuCategoryCreationFormInitializerDTO = new();

            return menuCategoryCreationFormInitializerDTO;
        }

        public async Task<MenuCategoryEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            MenuCategory menuCategory = await _menuCategoryRepository.GetEntityEditionFormInitializerAsync(id);

            return _mapper.Map<MenuCategoryEditionFormInitializerDTO>(menuCategory);
        }

        public async Task<IReadOnlyList<MenuDTO>> GetMenuAsync()
        {
            IReadOnlyList<MenuModel> menuesModel = await _menuCategoryRepository.GetMenuAsync();

            return _mapper.Map<IReadOnlyList<MenuDTO>>(menuesModel);
        }

        public async Task UpdateAsync(MenuCategoryFromFormDTO updateDTO, int id)
        {
            MenuCategory menuCategory = await GetMenuCategoryAsync(id);

            menuCategory = _mapper.Map(updateDTO, menuCategory);

            await _menuCategoryRepository.UpdateAsync(menuCategory);
        }

        public async Task UpdateMenuAsync(List<MenuDTO> menuDTOs)
        {
            List<MenuCategory> menuCategories = await _menuCategoryRepository.GetMenuToUpdateAsync();

            menuCategories = _mapper.Map(menuDTOs, menuCategories);

            await _menuCategoryRepository.UpdateMenuAsync(menuCategories);
        }

        private async Task<MenuCategory> GetMenuCategoryAsync(int id)
        {
            MenuCategory menuCategory = await _menuCategoryRepository.GetAsync(id);

            if (menuCategory is null) { throw new MenuCategoryNotFoundException(); }

            return menuCategory;
        }
    }
}
