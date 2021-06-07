using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.API.Controllers.Base
{
    [ApiController]
    [Route(template: BasePath + "/[controller]")]
    internal class BaseController : ControllerBase
    {
        protected const string BasePath = "api/restaurants-module";
    }
}
