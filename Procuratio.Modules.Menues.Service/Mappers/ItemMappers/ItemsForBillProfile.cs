using AutoMapper;
using Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Menu.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
