using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
