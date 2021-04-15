﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Cashes.Domain.Entities.State
{
    public class CashState : StateBaseEntity
    {
        public List<Cash> Cashes { get; set; }

        public enum State
        {
            Activa = 1,
            Inactiva,
            CajaCerrada
        }
    }
}
