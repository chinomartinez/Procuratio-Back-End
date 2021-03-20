using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Customers.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    public class BaseController : ControllerBase
    {
        protected const string BasePath = "api/customers-module";
    }
}
