using AutoMapper;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Order.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.Mappers.OrderMappers
{
    public class OrderForReportProfile : Profile
    {
        public OrderForReportProfile()
        {
            CreateMap<OrderForReport, OrderForReportDTO>();
        }
    }
}
