using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemFromFormDTO : IFromFormDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public string Image { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public string Code { get; set; }

        public int? MenuSubcategoryId { get; set; }
    }
}
