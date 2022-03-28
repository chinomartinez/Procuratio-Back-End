using Procuratio.Shared.ProcuratioFramework.HttpContextUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemForListFilterDTO
    {
        public int Page { get; set; }

        public int RecordsPerPage { get; set; }

        public PaginationDTO PaginacionDTO
        {
            get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public bool PriceInsideRestaurant { get; set; }

        public bool PriceOutsideRestaurant { get; set; }
    }
}
