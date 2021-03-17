using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Menues.API.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Menues.API.Controllers
{
    [ApiController]
    [Route(template: BasePath)]
    public class TemporalClassController : BaseController
    {
        // Solicitudes HTTP
        [HttpGet]
        public ActionResult<string> Get() => "Menues module";
    }
}
