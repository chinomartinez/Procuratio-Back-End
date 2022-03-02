using Procuratio.Shared.ProcuratioFramework.HttpContextUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderInProgressFilterDTO
    {
        //public int Page { get; set; }

        //public int RecordsPerPage { get; set; }

        //public PaginationDTO PaginacionDTO
        //{
        //    get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        //}

        public List<short> OrderStateIdList { get; set; } = new();
    }
}
