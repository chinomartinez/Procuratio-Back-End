using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Controllers
{
    public static class BasicStringsForControllers
    {
        public const string EntityCreationFormInitializer = "entity-creation-form-initializer";
        public const string EntityEditionFormInitializer = "entity-edition-form-initializer" + "/" + IntParameter;

        public const string IntParameter = "{id:int}";
    }
}
