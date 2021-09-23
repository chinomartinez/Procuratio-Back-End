using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;

namespace Procuratio.Modules.Security.Service.Mappers.UserMappers
{
    public class UserFromFormProfile : Profile
    {
        public UserFromFormProfile()
        {
            CreateMap<UserFromFormDTO, User>();
        }
    }
}
