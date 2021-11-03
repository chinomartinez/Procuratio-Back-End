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
        private readonly int BranchId;
        private readonly HttpContext _httpContext;

        public TenantService(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext;

            if (_httpContext is not null)
            {
                if (ItsAnonymousEndPoint()) { return; }

                BranchId = Convert.ToInt32(_httpContext.User.Claims.FirstOrDefault(x => x.Type == JWTClaimNames.BranchId).Value);

                if (BranchId <= 0) { throw new BranchIdNotFoundException(); }
            }
        }

        public int GetBranchId()
        {
            const int itsAnonymousEndPoint = -1;

            if (ItsAnonymousEndPoint()) { return itsAnonymousEndPoint; }

            if (BranchId <= 0 && _httpContext is not null) { throw new BranchIdNotFoundException(); }

            return BranchId;
        }

        private bool ItsAnonymousEndPoint()
        {
            Endpoint endpoint = _httpContext?.GetEndpoint();

            return endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is object;
        }
    }
}
