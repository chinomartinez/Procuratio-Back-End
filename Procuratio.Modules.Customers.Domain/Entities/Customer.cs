using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Customers.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }
    }
}
