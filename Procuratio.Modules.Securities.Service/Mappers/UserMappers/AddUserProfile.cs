using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;

namespace Procuratio.Modules.Securities.Service.Mappers
{
    internal class AddUserProfile : Profile
    {
        public AddUserProfile()
        {
            CreateMap<AddUserDTO, User>();
        }
    }
}
