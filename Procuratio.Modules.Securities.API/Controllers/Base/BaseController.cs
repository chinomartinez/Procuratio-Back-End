using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Securities.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    internal abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api/securities-module";
    }
}
