using AutoMapper;
using Procuratio.Modules.Menu.Service.DTOs.ItemDTOs;
using Procuratio.Modules.Menues.Domain.Entities;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDTO>();
        }
    }
}
