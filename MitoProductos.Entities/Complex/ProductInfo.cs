using System;
using System.Collections.Generic;
using System.Text;

namespace MitoProducts.Entities.Complex
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
