using AutoMapper;
using Procuratio.Modules.Order.Domain.Entities.intermediate;
using Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework;
using System;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.Mappers.WithoutReserveMappers
{
    public class WithoutReserveFromFormProfile : Profile
    {
        public WithoutReserveFromFormProfile()
        {
            CreateMap<WithoutReserveFromFormDTO, WithoutReserve>()
             .ForMember(x => x.Password, x => x.MapFrom(x => string.Empty))
             .ForMember(x => x.Order, options => options.MapFrom(MapOrder));
        }

        private Orders.Domain.Entities.Order MapOrder(WithoutReserveFromFormDTO withoutReserveFromFormDTO, WithoutReserve withoutReserve)
        {
            if (withoutReserve.Id != 0)
            {
                withoutReserve.Order.TableXOrders.Clear();
            }
            else
            {
                withoutReserve.Order = new Orders.Domain.Entities.Order
                {
                    OrderStateId = (short)OrderState.State.Pending,
                    WaiterId = withoutReserveFromFormDTO.UserId,
                    CustomerId = TGRID.CustomerId,
                    Date = DateTime.Now,
                    TableXOrders = new List<TableXOrder>()
                };
            }

            withoutReserveFromFormDTO.TablesIds.ForEach(x => withoutReserve.Order.TableXOrders.Add(new() { TableId = x }));

            return withoutReserve.Order;
        }
    }
}
