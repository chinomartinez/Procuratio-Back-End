using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Shared.DTO;

namespace Procuratio.Modules.Menu.Service.Mappers.ItemMappers
{
    public class ItemsForBillProfile : Profile
    {
        public ItemsForBillProfile()
        {
            CreateMap<ItemsBill, ItemsForBillDTO>();
        }
    }
}
