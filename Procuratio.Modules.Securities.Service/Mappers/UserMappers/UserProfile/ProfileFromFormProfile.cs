using AutoMapper;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.Service.DTOs.UserDTOs.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.Service.Mappers.UserMappers.UserProfile
{
    public class ProfileFromFormProfile : Profile
    {
        public ProfileFromFormProfile()
        {
            CreateMap<ProfileFromFormDTO, User>().ForMember(x => x.ProfilePicture, options => options.Ignore());
        }
    }
}
