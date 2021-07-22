using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Restaurants.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        protected const string BasePath = "api/restaurant-module";
    }
}
