using Microsoft.AspNetCore.Http;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemFromFormDTO : IFromFormDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public IFormFile Image { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public string Code { get; set; }

        public int? MenuCategoryId { get; set; }
    }
}
