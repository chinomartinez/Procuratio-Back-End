using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Orders.API.Controllers.BaseControllers
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "orders-module";
    }
}
