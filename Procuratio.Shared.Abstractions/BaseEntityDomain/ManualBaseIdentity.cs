using System.ComponentModel.DataAnnotations.Schema;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class ManualBaseIdentity<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TKey Id { get; set; }
    }
}
