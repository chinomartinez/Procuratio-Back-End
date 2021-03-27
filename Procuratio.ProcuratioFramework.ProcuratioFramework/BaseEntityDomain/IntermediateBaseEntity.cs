using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class IntermediateBaseEntity : IRestaurant
    {
        public int RestaurantID { get; set; }
    }
}
