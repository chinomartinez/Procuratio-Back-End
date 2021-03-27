using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain
{
    public abstract class BaseEntity<TKey> : BaseIdentity<TKey>, IRestaurant
    {
        public int RestaurantID { get; set; }
    }
}
