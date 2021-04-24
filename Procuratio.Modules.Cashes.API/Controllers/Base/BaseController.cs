using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Cashes.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api/cashes-module";
    }
}
