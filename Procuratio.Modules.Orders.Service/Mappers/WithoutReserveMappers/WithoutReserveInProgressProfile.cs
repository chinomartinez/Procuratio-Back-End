﻿using AutoMapper;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveInProgressProfile : Profile
    {
        public WithoutReserveInProgressProfile()
        {
            CreateMap<WithoutReserve, WithoutReserveInProgressDTO>()
                .ForMember(x => x.WithoutReserve, x => x.MapFrom(x => x))
                .ForMember(x => x.OrderID, x => x.MapFrom(x => x.Order.ID))
                .ForMember(x => x.OrderStateID, x => x.MapFrom(x => x.Order.OrderStateID))
                .ForMember(x => x.OrderStateName, x => x.MapFrom(x => x.Order.OrderState.StateName))
                .ForMember(x => x.WaitersName, x => x.MapFrom(x => TGRID.WaitersName))
                .ForMember(x => x.WithoutReserveTableNumbers, options => options.MapFrom(MapWithoutReserveTableNumbers));
        }

        private List<string> MapWithoutReserveTableNumbers(WithoutReserve withoutReserve, WithoutReserveInProgressDTO withoutReserveInProgressDTO)
        {
            List<string> result = new();

            const int maxCharacterTableNumberLenght = 3;

            withoutReserve.TableXWithoutReserve.ForEach(x => result.Add(x.Table.Number.ToString().PadLeft(maxCharacterTableNumberLenght, '0')));

            return result;
        }
    }
}
