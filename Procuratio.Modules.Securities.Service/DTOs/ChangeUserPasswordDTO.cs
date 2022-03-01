using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.Service.DTOs
{
    public class ChangeUserPasswordDTO
    {
        public string CurrentPassword { get; set; }

        public string Password { get; set; }
    }
}
