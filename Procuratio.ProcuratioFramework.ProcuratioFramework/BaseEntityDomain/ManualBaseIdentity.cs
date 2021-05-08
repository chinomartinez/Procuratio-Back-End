using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class ManualBaseIdentity<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TKey ID { get; set; }
    }
}
