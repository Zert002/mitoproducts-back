using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitoProductsApi.Filters
{
    public class MitoProductsException : Exception
    {
        public MitoProductsException(string message) : base(message)
        {
        }
    }
}
