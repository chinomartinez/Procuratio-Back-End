using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Orders.API.Controllers.BaseControllers
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api/orders-module";
    }
}
