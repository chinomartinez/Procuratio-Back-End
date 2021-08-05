using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
