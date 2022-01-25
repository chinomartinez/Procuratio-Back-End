using AutoMapper;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Mappers
{
    public class BranchForMenuProfile : Profile
    {
        public BranchForMenuProfile()
        {
            CreateMap<BranchForMenuModel, BranchForMenuDTO>();
        }
    }
}
