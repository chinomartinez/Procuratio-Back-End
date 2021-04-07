using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class StateBaseEntity : BaseIdentity<int>
    {
        public string StateName { get; set; }
    }
}
