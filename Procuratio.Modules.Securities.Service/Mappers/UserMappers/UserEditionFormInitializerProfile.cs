using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;

namespace Procuratio.Modules.Security.Service.Mappers.UserMappers
{
    public class UserEditionFormInitializerProfile : Profile
    {
        public UserEditionFormInitializerProfile()
        {
            CreateMap<User, UserEditionFormInitializerDTO>()
                .ForMember(x => x.BaseProperties, x => x.MapFrom(x => x));
        }
    }
}
