using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected const string BasePath = "api/menues-module";
    }
}
