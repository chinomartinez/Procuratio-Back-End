using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Menues.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    internal abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api/menu-module";
    }
}
