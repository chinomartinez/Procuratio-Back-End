using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Procuratio.Shared.ProcuratioFramework.JWT
{
    public static class JWTClaims
    {
        public static string GetBranchId(HttpContext httpContext) => GetClaimData(httpContext, JWTClaimNames.BranchId);

        public static string GetUserFullName(HttpContext httpContext) => GetClaimData(httpContext, JWTClaimNames.UserFullName);

        public static string GetRole(HttpContext httpContext) => GetClaimData(httpContext, ClaimTypes.Role);

        private static string GetClaimData(HttpContext httpContext, string claimName)
        {
            return httpContext.User.Claims.First(x => x.Type == claimName).Value;
        }
    }
}
