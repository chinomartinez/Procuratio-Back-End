using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs.Profile
{
    public class ProfileFromFormDTO
    {
        public IFormFile ProfilePicture { get; set; }
    }
}
