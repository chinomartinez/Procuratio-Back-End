using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.HttpContextUtilities
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;

        private int DefaultRecordsPerPage = 10;

        private readonly int cantidadMaximaRecordsPorPagina = 50;

        public int RecordsPerPage
        {
            get
            {
                return DefaultRecordsPerPage;
            }
            set
            {
                DefaultRecordsPerPage = (value > cantidadMaximaRecordsPorPagina) ? cantidadMaximaRecordsPorPagina : value;
            }
        }
    }
}
