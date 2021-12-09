﻿using Microsoft.AspNetCore.Identity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity
{
    public class UserToken : IdentityUserToken<int>, ITenant
    {
        public int BranchId { get; set; }
    }
}
