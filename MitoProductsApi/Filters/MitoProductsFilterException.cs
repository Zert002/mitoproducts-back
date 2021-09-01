using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitoProductsApi.Filters
{
    public class MitoProductsFilterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MitoProductsException)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
