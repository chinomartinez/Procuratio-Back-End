using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Abstractions.Tenant
{
    public interface ITenantService
    {
        public int GetBranchId();
    }
}
