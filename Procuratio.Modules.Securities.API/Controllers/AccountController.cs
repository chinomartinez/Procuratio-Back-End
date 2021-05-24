using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Securities.API.Controllers.Base;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Securities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.API.Controllers
{
    internal class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        //[HttpPost("create")]
        //public async Task<ActionResult<AuthenticationResponseDTO>> Create([FromBody] UserCredentialsDTO userCredentialsDTO)
        //{

        //}
    }
}
