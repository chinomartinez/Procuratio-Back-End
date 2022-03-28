using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Procuratio.Shared.ProcuratioFramework.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.HttpContextUtilities
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParametersOnHeader<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext == null) { throw new HttpContextNullException(nameof(httpContext)); }

            double quantity = await queryable.CountAsync();
            httpContext.Response.Headers.Add("totalNumberOfRecords", quantity.ToString());
        }
    }
}
