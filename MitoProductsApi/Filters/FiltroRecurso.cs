using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MitoProductsApi.Filters
{
    public class FiltroRecurso : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            Debug.WriteLine(MethodBase.GetCurrentMethod(), context.HttpContext.Request.Path);
        }
    }
}
