using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Cashes.Domain.Entities
{
    public class MovementType : BaseEntity<int>
    {
        public int MovementTypeID { get; set; }
        public MovementType MovementsType { get; set; }
    }
}
