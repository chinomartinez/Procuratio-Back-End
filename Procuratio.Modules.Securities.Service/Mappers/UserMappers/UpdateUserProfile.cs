using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;

namespace Procuratio.Modules.Securities.Service.Mappers
{
    internal class UpdateUserProfile : Profile
    {
        public UpdateUserProfile()
        {
            CreateMap<User, UpdateUserDTO>();
        }
    }
}
