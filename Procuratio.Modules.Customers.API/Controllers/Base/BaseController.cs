using Microsoft.AspNetCore.Mvc;

namespace Procuratio.Modules.Customers.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    public class BaseController : ControllerBase
    {
        protected const string BasePath = "api/customer-module";
    }
}
