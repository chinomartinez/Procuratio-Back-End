using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.DineInDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.DinerInMappers
{
    public class DineInListProfile : Profile
    {
        public DineInListProfile()
        {
            CreateMap<DineIn, DineInForListDTO>()
                .ForMember(x => x.DineIn, x => x.MapFrom(x => x))
                .ForMember(x => x.StateName, x => x.MapFrom(x => x.DinerInState.StateName))
                .ForMember(x => x.OrderStateID, x => x.MapFrom(x => x.Order.OrderStateID))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.TableNumbers, options => options.MapFrom(MapTableNumbers));
        }

        private List<string> MapTableNumbers(DineIn dineIn, DineInForListDTO dineInForListDTO)
        {
            List<string> result = new();

            dineIn.TableXDinerIn.ForEach(x => result.Add(x.Table.Number.ToString()));

            return result;
        }
    }
}
