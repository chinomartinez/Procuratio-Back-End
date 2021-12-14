﻿using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Procuratio.Shared.ProcuratioFramework.JWT
{
    public static class JWTClaims
    {
        public static string GetBranchId(HttpContext httpContext) => GetClaimData(httpContext, JWTClaimNames.BranchId);

        public static string GetUserFullName(HttpContext httpContext) => GetClaimData(httpContext, JWTClaimNames.UserFullName);

        public static string GetRole(HttpContext httpContext) => GetClaimData(httpContext, JWTClaimNames.Role);

        private static string GetClaimData(HttpContext httpContext, string claimName)
        {
            return httpContext.User.Claims.First(x => x.Type == claimName).Value;
        }
    }
}
