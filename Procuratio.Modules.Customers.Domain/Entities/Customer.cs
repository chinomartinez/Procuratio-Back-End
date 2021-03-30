using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Customers.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }
    }
}
