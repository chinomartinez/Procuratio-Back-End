using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Customers.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        protected const string BasePath = "api/customer-module";
    }
}
