using System.ComponentModel.DataAnnotations;

namespace MitoProductos.Entities
{
    public class Product : EntityBase
    {

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public decimal UnitPrice { get; set; }
        public bool Enabled { get; set; }

    }
}
