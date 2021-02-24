using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.API.Controllers.BaseControllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Orders.API.Controllers
{
    [Route(template: BasePath)]
    public class TemporalClassController : BaseController
    {
        // Solicitudes HTTP
        [HttpGet]
        public ActionResult<string> Get() => "Orders module";
    }
}
