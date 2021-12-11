using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.Exceptions;
using Procuratio.Shared.ProcuratioFramework.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Tenant
{
    public class TenantService : ITenantService
    {
        private readonly HttpContext _httpContext;

        public TenantService(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext;
        }

        public int GetBranchId()
        {
            int branchId = 0;

            if (ItsAnonymousEndPoint()) { return -1; }

            if (_httpContext is not null)
            {
                if (_httpContext.User.Claims.FirstOrDefault(x => x.Type == JWTClaimNames.BranchId) is not null)
                {
                    branchId = Convert.ToInt32(_httpContext.User.Claims.FirstOrDefault(x => x.Type == JWTClaimNames.BranchId).Value);
                
                    if (branchId <= 0) { throw new BranchIdNotFoundException(); }
                }
                else
                {
                    throw new BranchIdNotFoundException();
                }
            }

            return branchId;
        }

        private bool ItsAnonymousEndPoint()
        {
            Endpoint endpoint = _httpContext?.GetEndpoint();

            return endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object;
        }
    }
}
