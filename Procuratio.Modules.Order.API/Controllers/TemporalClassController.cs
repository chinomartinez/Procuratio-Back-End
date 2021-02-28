using Microsoft.AspNetCore.Mvc;
using Procuratio.Modules.Orders.API.Controllers.BaseControllers;

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
