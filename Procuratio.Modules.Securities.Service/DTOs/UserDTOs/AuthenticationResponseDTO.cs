using System;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
