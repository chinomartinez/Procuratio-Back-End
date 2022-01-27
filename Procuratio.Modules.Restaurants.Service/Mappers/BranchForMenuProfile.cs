using AutoMapper;
using Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models;
using Procuratio.Modules.Restaurant.Service.DTOs.Branch;

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
