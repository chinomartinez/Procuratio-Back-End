﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class CompoundKeyBaseEntity : IRestaurant
    {
        public int BranchID { get; set; }
    }
}
