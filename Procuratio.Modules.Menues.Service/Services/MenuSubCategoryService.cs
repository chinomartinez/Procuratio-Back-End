using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.Modules.Menu.Service.Exceptions;
using Procuratio.Modules.Menues.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Menues.Domain.Entities;
using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.Modules.Menues.Service.Services.Interfaces;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Service.Services
{
    internal class MenuSubCategoryService : IMenuSubcategoryService
    {
        private readonly IMenuSubcategoryRepository _menuSubcategoryRepository;
        private readonly IMapper _mapper;
        private readonly IMenuCategoryRepository _menuCategoryRepository;

        public MenuSubCategoryService(IMenuSubcategoryRepository menuSubcategoryRepository, IMapper mapper, IMenuCategoryRepository menuCategoryRepository)
        {
            _menuSubcategoryRepository = menuSubcategoryRepository;
            _mapper = mapper;
            _menuCategoryRepository = menuCategoryRepository;
        }

        public async Task AddAsync(MenuSubcategoryFromFormDTO addDTO)
        {
            MenuSubcategory menuSubategory = new();

            int nextOrder = await _menuSubcategoryRepository.GetNextOrderAsync((int)addDTO.MenuCategoryId);

            menuSubategory = _mapper.Map(addDTO, menuSubategory, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.MenuSubCategoryStateId = (short)MenuSubCategoryState.State.Available;
                    dest.Order = nextOrder;
                });
            });

            await _menuSubcategoryRepository.AddAsync(menuSubategory);
        }

        public async Task<IReadOnlyList<MenuSubcategoryForListDTO>> BrowseAsync()
        {
            IReadOnlyList<MenuSubcategory> menuSubcategories = await _menuSubcategoryRepository.BrowseAsync();

            return _mapper.Map<IReadOnlyList<MenuSubcategoryForListDTO>>(menuSubcategories);
        }

        public async Task DeleteAsync(int id)
        {
            MenuSubcategory menuCategories = await GetMenuSubcategoryAsync(id);
            await _menuSubcategoryRepository.DeleteAsync(menuCategories);
        }

        public async Task<MenuSubcategoryDTO> GetAsync(int id)
        {
            MenuSubcategory menuSubcategory = await GetMenuSubcategoryAsync(id);

            return _mapper.Map<MenuSubcategoryDTO>(menuSubcategory);
        }

        public async Task<MenuSubcategoryCreationFormInitializerDTO> GetEntityCreationFormInitializerAsync()
        {
            MenuSubcategoryCreationFormInitializerDTO menuSubcategoryCreationFormInitializerDTO = new();

            List<MenuCategory> menuCategories = await _menuCategoryRepository.GetAllAsync();

            menuCategories.ForEach(x => menuSubcategoryCreationFormInitializerDTO.MenuCategories.Add(new SelectListItemDTO() { Id = x.Id.ToString(), Description = x.Name }));

            return menuSubcategoryCreationFormInitializerDTO;
        }

        public async Task<MenuSubcategoryEditionFormInitializerDTO> GetEntityEditionFormInitializerAsync(int id)
        {
            MenuSubcategoryEditionFormInitializerDTO menuSubcategoryEditionFormInitializerDTO;

            MenuSubcategory menuSubcategoryToEdit = await _menuSubcategoryRepository.GetEntityEditionFormInitializerAsync(id);

            if (menuSubcategoryToEdit is null) { throw new MenuSubcategoryNotFoundException(); }

            menuSubcategoryEditionFormInitializerDTO = _mapper.Map<MenuSubcategoryEditionFormInitializerDTO>(menuSubcategoryToEdit);

            return menuSubcategoryEditionFormInitializerDTO;
        }

        public async Task UpdateAsync(MenuSubcategoryFromFormDTO updateDTO, int id)
        {
            MenuSubcategory menuSubcategory = await GetMenuSubcategoryAsync(id);

            updateDTO.MenuCategoryId = menuSubcategory.MenuCategoryId;

            menuSubcategory = _mapper.Map(updateDTO, menuSubcategory);

            await _menuSubcategoryRepository.UpdateAsync(menuSubcategory);
        }

        private async Task<MenuSubcategory> GetMenuSubcategoryAsync(int id)
        {
            MenuSubcategory menuSubcategory = await _menuSubcategoryRepository.GetAsync(id);

            if (menuSubcategory is null) { throw new MenuSubcategoryNotFoundException(); }

            return menuSubcategory;
        }
    }
}