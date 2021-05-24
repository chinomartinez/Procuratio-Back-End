using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Services.MicrosoftIdentity
{
    internal class UserService : IUserService
    {
        public UserService()
        {

        }


        //private async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credenciales)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim("email", credenciales.Email)
        //    };

        //    var usuario = await userManager.FindByEmailAsync(credenciales.Email);
        //    var claimsDB = await userManager.GetClaimsAsync(usuario);

        //    claims.AddRange(claimsDB);

        //    var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
        //    var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

        //    var expiracion = DateTime.UtcNow.AddYears(1);

        //    var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
        //        expires: expiracion, signingCredentials: creds);

        //    return new RespuestaAutenticacion()
        //    {
        //        Token = new JwtSecurityTokenHandler().WriteToken(token),
        //        Expiracion = expiracion
        //    };
        //}
    }
}
