using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Menues.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    internal abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api/menu-module";
    }
}
