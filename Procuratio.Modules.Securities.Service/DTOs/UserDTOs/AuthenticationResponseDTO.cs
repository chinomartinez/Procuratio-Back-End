using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
