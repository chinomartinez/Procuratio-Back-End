using Procuratio.Modules.Cashes.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class Cash : BaseEntity<int>
    {
        public DateTime Date { get; set; }

        public decimal Mount { get; set; }

        public string Detail { get; set; }

        public int OrderID { get; set; }

        public int MountTypeID { get; set; }
        public MountType MountType { get; set; }

        public short CashStateID { get; internal set; }
        public CashState CashState { get; set; }

        public int UserID { get; set; }
    }
}
